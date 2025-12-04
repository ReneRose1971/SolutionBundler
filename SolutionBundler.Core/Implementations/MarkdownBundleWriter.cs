using System.Text;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Implementations;

/// <summary>
/// Schreibt ein Markdown-Bundle aus den übergebenen Solution-Daten und Dateien.
/// Die Ausgabedatei wird standardmäßig unter MyDocuments\Solutionbundler\bundles\{SolutionName}.md gespeichert.
/// </summary>
public sealed class MarkdownBundleWriter : IBundleWriter
{
    private readonly ISecretMasker _masker;

    /// <summary>
    /// Erstellt einen neuen Writer mit einem Secret-Masker zum Entfernen sensibler Informationen.
    /// </summary>
    /// <param name="masker">Implementierung, die Geheimnisse in Dateiinhalten maskiert.</param>
    public MarkdownBundleWriter(ISecretMasker masker) => _masker = masker;

    /// <summary>
    /// Schreibt das Bundle als Markdown-Datei.
    /// </summary>
    /// <param name="info">Metadaten zur Solution (RootPath, SolutionName, etc.).</param>
    /// <param name="files">Sammlung von Dateien, die ins Bundle aufgenommen werden sollen.</param>
    /// <param name="settings">Einstellungen für Scan und Ausgabe (z. B. MaskSecrets).</param>
    /// <returns>Vollständiger Pfad zur erzeugten Markdown-Datei.</returns>
    public string Write(SolutionInfo info, IEnumerable<FileEntry> files, ScanSettings settings)
    {
        var root = info.RootPath;
        var list = files.ToList();

        var sb = new StringBuilder();
        sb.AppendLine("---");
        sb.AppendLine($"solution_root: {Path.GetFileName(root)}");
        sb.AppendLine($"generated_at: {info.GeneratedAt:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine("tool: SolutionBundler v1");
        sb.AppendLine($"dotnet_hint: \"{info.DotnetHint}\"");
        sb.AppendLine("---");
        sb.AppendLine("# Inhaltsverzeichnis");

        foreach (var f in list)
        {
            var anchor = ToAnchor(f.RelativePath);
            sb.AppendLine($"* [{f.RelativePath}](#{anchor})");
        }

        sb.AppendLine();
        sb.AppendLine("# Dateien");

        foreach (var f in list)
        {
            var anchor = ToAnchor(f.RelativePath);
            sb.AppendLine();
            sb.AppendLine($"## {f.RelativePath}");
            sb.AppendLine($"_size_: {f.Size} bytes - _sha1_: {f.Sha1} - _action_: {f.Action}");
            sb.AppendLine();
            sb.AppendLine($"--- FILE: {f.RelativePath} | HASH: {f.Sha1} | ACTION: {f.Action} ---");

            var fence = string.IsNullOrWhiteSpace(f.Language) ? "```" : $"```{f.Language}";
            sb.AppendLine(fence);

            string content;
            try
            {
                content = File.ReadAllText(f.FullPath);
                if (settings.MaskSecrets) content = _masker.Process(f.RelativePath, content);
            }
            catch
            {
                content = $"/* FEHLER: Datei konnte nicht gelesen werden: {f.FullPath} */";
            }

            sb.AppendLine(content);
            sb.AppendLine("```");
        }

        // Output path: MyDocuments/Solutionbundler/bundles, filename = solution/project name + .md
        var myDocs = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        var outDir = Path.Combine(myDocs, "Solutionbundler", "bundles");
        if (!Directory.Exists(outDir)) Directory.CreateDirectory(outDir);

        var baseName = string.IsNullOrWhiteSpace(info.SolutionName) ? Path.GetFileName(root) : info.SolutionName;
        var fileName = Path.GetFileNameWithoutExtension(baseName) + ".md";
        var outputPath = Path.Combine(outDir, fileName);

        File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        return outputPath;

        static string ToAnchor(string rel) =>
            rel.Replace('\\','/').ToLowerInvariant()
               .Replace(' ','-').Replace('/','-').Replace('.','-').Replace(':','-');
    }
}