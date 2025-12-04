using System.Xml.Linq;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Implementations;

/// <summary>
/// Liest aus .csproj-Dateien die in den ItemGroups angegebenen BuildActions und ordnet diese den gefundenen Dateien zu.
/// </summary>
public sealed class MsBuildProjectMetadataReader : IProjectMetadataReader
{
    /// <summary>
    /// Ergänzt die übergebene Liste von FileEntry-Objekten um die erkannten BuildActions anhand der .csproj-Inhalte.
    /// </summary>
    /// <param name="entries">Liste der Dateieinträge, die erweitert werden sollen.</param>
    /// <param name="rootPath">Root-Pfad der Solution, zur Berechnung relativer Dateipfade.</param>
    public void EnrichBuildActions(IList<FileEntry> entries, string rootPath)
    {
        // einfache Heuristik: aus allen csproj BuildActions lesen und auf Einträge mappen
        var csprojs = entries.Where(f => f.RelativePath.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase)).ToList();
        var map = new Dictionary<string, BuildAction>(StringComparer.OrdinalIgnoreCase);

        foreach (var proj in csprojs)
        {
            try
            {
                var doc = XDocument.Load(proj.FullPath);
                foreach (var ig in doc.Descendants("ItemGroup"))
                {
                    foreach (var item in ig.Elements())
                    {
                        var include = item.Attribute("Include")?.Value;
                        if (string.IsNullOrWhiteSpace(include)) continue;

                        var action = item.Name.LocalName switch
                        {
                            "Compile" => BuildAction.Compile,
                            "Page" => BuildAction.Page,
                            "Resource" => BuildAction.Resource,
                            "Content" => BuildAction.Content,
                            _ => BuildAction.Unknown
                        };

                        var projDir = Path.GetDirectoryName(proj.FullPath)!;
                        var candidate = Path.GetFullPath(Path.Combine(projDir, include));
                        var rel = Path.GetRelativePath(rootPath, candidate).Replace('\\','/');
                        if (!map.ContainsKey(rel)) map[rel] = action;
                    }
                }
            }
            catch
            {
                // robust: bei Parsingfehlern einfach fortfahren
            }
        }

        foreach (var e in entries)
        {
            if (map.TryGetValue(e.RelativePath, out var act)) e.Action = act;
            else
            {
                // Fallback nach Extension
                e.Action = Path.GetExtension(e.RelativePath).ToLowerInvariant() switch
                {
                    ".cs" => BuildAction.Compile,
                    ".xaml" => BuildAction.Page,
                    ".resx" => BuildAction.Resource,
                    ".json" or ".config" or ".props" or ".targets" => BuildAction.Content,
                    _ => BuildAction.Unknown
                };
            }
        }
    }
}