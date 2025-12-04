---
solution_root: SolutionBundler
generated_at: 2025-12-02 17:50:52
tool: SolutionBundler v1
dotnet_hint: "Bitte .NET SDK Version in README prüfen"
---
# Inhaltsverzeichnis
* [Directory.Build.props](#directory-build-props)
* [SolutionBundler.Core/Abstractions/IBundleOrchestrator.cs](#solutionbundler-core-abstractions-ibundleorchestrator-cs)
* [SolutionBundler.Core/Abstractions/IBundleWriter.cs](#solutionbundler-core-abstractions-ibundlewriter-cs)
* [SolutionBundler.Core/Abstractions/IContentClassifier.cs](#solutionbundler-core-abstractions-icontentclassifier-cs)
* [SolutionBundler.Core/Abstractions/IFileScanner.cs](#solutionbundler-core-abstractions-ifilescanner-cs)
* [SolutionBundler.Core/Abstractions/IHashCalculator.cs](#solutionbundler-core-abstractions-ihashcalculator-cs)
* [SolutionBundler.Core/Abstractions/IProjectMetadataReader.cs](#solutionbundler-core-abstractions-iprojectmetadatareader-cs)
* [SolutionBundler.Core/Abstractions/ISecretMasker.cs](#solutionbundler-core-abstractions-isecretmasker-cs)
* [SolutionBundler.Core/Class1.cs](#solutionbundler-core-class1-cs)
* [SolutionBundler.Core/Implementations/BundleOrchestrator.cs](#solutionbundler-core-implementations-bundleorchestrator-cs)
* [SolutionBundler.Core/Implementations/DefaultFileScanner.cs](#solutionbundler-core-implementations-defaultfilescanner-cs)
* [SolutionBundler.Core/Implementations/MarkdownBundleWriter.cs](#solutionbundler-core-implementations-markdownbundlewriter-cs)
* [SolutionBundler.Core/Implementations/MsBuildProjectMetadataReader.cs](#solutionbundler-core-implementations-msbuildprojectmetadatareader-cs)
* [SolutionBundler.Core/Implementations/RegexSecretMasker.cs](#solutionbundler-core-implementations-regexsecretmasker-cs)
* [SolutionBundler.Core/Implementations/Sha1HashCalculator.cs](#solutionbundler-core-implementations-sha1hashcalculator-cs)
* [SolutionBundler.Core/Implementations/SimpleContentClassifier.cs](#solutionbundler-core-implementations-simplecontentclassifier-cs)
* [SolutionBundler.Core/Models/BuildAction.cs](#solutionbundler-core-models-buildaction-cs)
* [SolutionBundler.Core/Models/FileEntry.cs](#solutionbundler-core-models-fileentry-cs)
* [SolutionBundler.Core/Models/ScanSettings.cs](#solutionbundler-core-models-scansettings-cs)
* [SolutionBundler.Core/Models/SolutionInfo.cs](#solutionbundler-core-models-solutioninfo-cs)
* [SolutionBundler.Core/ServiceCollectionExtensions.cs](#solutionbundler-core-servicecollectionextensions-cs)
* [SolutionBundler.Core/SolutionBundler.Core.csproj](#solutionbundler-core-solutionbundler-core-csproj)
* [SolutionBundler.sln](#solutionbundler-sln)
* [SolutionBundler.Tests/DefaultFileScannerTests.cs](#solutionbundler-tests-defaultfilescannertests-cs)
* [SolutionBundler.Tests/HashAndClassifierTests.cs](#solutionbundler-tests-hashandclassifiertests-cs)
* [SolutionBundler.Tests/MsBuildProjectMetadataReaderTests.cs](#solutionbundler-tests-msbuildprojectmetadatareadertests-cs)
* [SolutionBundler.Tests/RegexSecretMaskerTests.cs](#solutionbundler-tests-regexsecretmaskertests-cs)
* [SolutionBundler.Tests/SmokeTests.cs](#solutionbundler-tests-smoketests-cs)
* [SolutionBundler.Tests/SolutionBundler.Tests.csproj](#solutionbundler-tests-solutionbundler-tests-csproj)
* [SolutionBundler.Tests/UnitTest1.cs](#solutionbundler-tests-unittest1-cs)
* [SolutionBundler.WPF/App.xaml](#solutionbundler-wpf-app-xaml)
* [SolutionBundler.WPF/App.xaml.cs](#solutionbundler-wpf-app-xaml-cs)
* [SolutionBundler.WPF/AssemblyInfo.cs](#solutionbundler-wpf-assemblyinfo-cs)
* [SolutionBundler.WPF/MainWindow.xaml](#solutionbundler-wpf-mainwindow-xaml)
* [SolutionBundler.WPF/MainWindow.xaml.cs](#solutionbundler-wpf-mainwindow-xaml-cs)
* [SolutionBundler.WPF/SolutionBundler.WPF.csproj](#solutionbundler-wpf-solutionbundler-wpf-csproj)

# Dateien

## Directory.Build.props
_size_: 235 bytes - _sha1_: 8fdc11822a6a565529d6371b261831c930903966 - _action_: Content

--- FILE: Directory.Build.props | HASH: 8fdc11822a6a565529d6371b261831c930903966 | ACTION: Content ---
```xml
<Project>
  <PropertyGroup>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
    <TreatWarningsAsErrors>false</TreatWarningsAsErrors>
  </PropertyGroup>
</Project>
```

## SolutionBundler.Core/Abstractions/IBundleOrchestrator.cs
_size_: 361 bytes - _sha1_: 83f132ad69887e7ae96557d09dc7987a58b6d0b0 - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/IBundleOrchestrator.cs | HASH: 83f132ad69887e7ae96557d09dc7987a58b6d0b0 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Models;
using System;

namespace SolutionBundler.Core.Abstractions;

public interface IBundleOrchestrator
{
    string Run(string rootPath, ScanSettings settings);

    // Optional progress-aware overload. Progress reports should be 0-100.
    string Run(string rootPath, ScanSettings settings, IProgress<int>? progress);
}
```

## SolutionBundler.Core/Abstractions/IBundleWriter.cs
_size_: 213 bytes - _sha1_: 0d994453947891036ed47135975c1e94925b0875 - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/IBundleWriter.cs | HASH: 0d994453947891036ed47135975c1e94925b0875 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IBundleWriter
{
    string Write(SolutionInfo info, IEnumerable<FileEntry> files, ScanSettings settings);
}
```

## SolutionBundler.Core/Abstractions/IContentClassifier.cs
_size_: 128 bytes - _sha1_: 57b1de90bd4b25c58244a9c74718296d5e8c7fbe - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/IContentClassifier.cs | HASH: 57b1de90bd4b25c58244a9c74718296d5e8c7fbe | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core.Abstractions;

public interface IContentClassifier
{
    string Classify(string filePath);
}
```

## SolutionBundler.Core/Abstractions/IFileScanner.cs
_size_: 197 bytes - _sha1_: a9a58f4572d2e50b8814a3acd620dbba6e441fb8 - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/IFileScanner.cs | HASH: a9a58f4572d2e50b8814a3acd620dbba6e441fb8 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IFileScanner
{
    IReadOnlyList<FileEntry> Scan(string rootPath, ScanSettings settings);
}
```

## SolutionBundler.Core/Abstractions/IHashCalculator.cs
_size_: 118 bytes - _sha1_: 40a6668e05370afc04b1f966eafb0889ed9e4167 - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/IHashCalculator.cs | HASH: 40a6668e05370afc04b1f966eafb0889ed9e4167 | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core.Abstractions;

public interface IHashCalculator
{
    string Sha1(byte[] bytes);
}
```

## SolutionBundler.Core/Abstractions/IProjectMetadataReader.cs
_size_: 204 bytes - _sha1_: 99d9e22864f73eb89f4bee4f2461364653b34b65 - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/IProjectMetadataReader.cs | HASH: 99d9e22864f73eb89f4bee4f2461364653b34b65 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IProjectMetadataReader
{
    void EnrichBuildActions(IList<FileEntry> entries, string rootPath);
}
```

## SolutionBundler.Core/Abstractions/ISecretMasker.cs
_size_: 142 bytes - _sha1_: 6f1ec0463f3f30e78dffd1cdd9aa3ad1de5fb1ae - _action_: Compile

--- FILE: SolutionBundler.Core/Abstractions/ISecretMasker.cs | HASH: 6f1ec0463f3f30e78dffd1cdd9aa3ad1de5fb1ae | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core.Abstractions;

public interface ISecretMasker
{
    string Process(string relativePath, string content);
}
```

## SolutionBundler.Core/Class1.cs
_size_: 67 bytes - _sha1_: e0dfd1fb9e40ad08d51fb102861ceabccba61bd5 - _action_: Compile

--- FILE: SolutionBundler.Core/Class1.cs | HASH: e0dfd1fb9e40ad08d51fb102861ceabccba61bd5 | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core;

public class Class1
{

}

```

## SolutionBundler.Core/Implementations/BundleOrchestrator.cs
_size_: 2482 bytes - _sha1_: 6ccce1cb92a5cb1b264b7071ebde6b6f41741e80 - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/BundleOrchestrator.cs | HASH: 6ccce1cb92a5cb1b264b7071ebde6b6f41741e80 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;
using System;

namespace SolutionBundler.Core.Implementations;

public sealed class BundleOrchestrator : IBundleOrchestrator
{
    private readonly IFileScanner _scanner;
    private readonly IProjectMetadataReader _metadata;
    private readonly IContentClassifier _classifier;
    private readonly IHashCalculator _hasher;
    private readonly IBundleWriter _writer;

    public BundleOrchestrator(
        IFileScanner scanner,
        IProjectMetadataReader metadata,
        IContentClassifier classifier,
        IHashCalculator hasher,
        IBundleWriter writer)
    {
        _scanner = scanner;
        _metadata = metadata;
        _classifier = classifier;
        _hasher = hasher;
        _writer = writer;
    }

    public string Run(string rootPath, ScanSettings settings) => Run(rootPath, settings, null);

    public string Run(string rootPath, ScanSettings settings, IProgress<int>? progress)
    {
        progress?.Report(0);

        var files = _scanner.Scan(rootPath, settings).ToList();
        progress?.Report(10);

        // Hash + Language
        var total = files.Count;
        for (int i = 0; i < total; i++)
        {
            var f = files[i];
            try
            {
                var bytes = File.ReadAllBytes(f.FullPath);
                f.Sha1 = _hasher.Sha1(bytes);
            }
            catch
            {
                f.Sha1 = "";
            }
            f.Language = _classifier.Classify(f.FullPath);

            // report progress between 10..70 during per-file processing
            var per = 10 + (int)((i + 1) / (double)Math.Max(1, total) * 60);
            progress?.Report(Math.Min(70, per));
        }

        progress?.Report(75);
        _metadata.EnrichBuildActions(files, rootPath);
        progress?.Report(85);

        var slnName = Directory.EnumerateFiles(rootPath, "*.sln", SearchOption.TopDirectoryOnly)
                               .Select(Path.GetFileName)
                               .FirstOrDefault() ?? "Solution";

        var info = new SolutionInfo
        {
            RootPath = rootPath,
            SolutionName = slnName
        };

        // Writing will be last step
        progress?.Report(90);
        var result = _writer.Write(info, files, settings);
        progress?.Report(100);
        return result;
    }
}
```

## SolutionBundler.Core/Implementations/DefaultFileScanner.cs
_size_: 1715 bytes - _sha1_: c7d9d1cd9514adac459896e6612b404c07459ef5 - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/DefaultFileScanner.cs | HASH: c7d9d1cd9514adac459896e6612b404c07459ef5 | ACTION: Compile ---
```csharp
using System.IO;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Implementations;

public sealed class DefaultFileScanner : IFileScanner
{
    public IReadOnlyList<FileEntry> Scan(string rootPath, ScanSettings settings)
    {
        var root = Path.GetFullPath(rootPath);
        var files = new List<FileEntry>();

        bool IsExcludedDir(string path) =>
            settings.ExcludeDirs.Any(d => path.Contains(Path.DirectorySeparatorChar + d + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase));

        bool IsExcludedFile(string file) =>
            settings.ExcludeGlobs.Any(glob => file.EndsWith(glob.Replace("*",""), StringComparison.OrdinalIgnoreCase));

        foreach (var pattern in settings.IncludePatterns)
        {
            foreach (var file in Directory.EnumerateFiles(root, pattern, SearchOption.AllDirectories))
            {
                var full = Path.GetFullPath(file);
                if (IsExcludedDir(full) || IsExcludedFile(full)) continue;

                var rel = Path.GetRelativePath(root, full);
                var fi = new FileInfo(full);
                files.Add(new FileEntry
                {
                    FullPath = full,
                    RelativePath = rel.Replace('\\','/'),
                    Size = fi.Length
                });
            }
        }

        // Distinct by relative path
        return files
            .GroupBy(f => f.RelativePath, StringComparer.OrdinalIgnoreCase)
            .Select(g => g.First())
            .OrderBy(f => f.RelativePath, StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}
```

## SolutionBundler.Core/Implementations/MarkdownBundleWriter.cs
_size_: 4510 bytes - _sha1_: 4c1c443a0ba4d1f02e3f32d19bd07c3e9ad5e205 - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/MarkdownBundleWriter.cs | HASH: 4c1c443a0ba4d1f02e3f32d19bd07c3e9ad5e205 | ACTION: Compile ---
```csharp
using System;
using System.Text;
using System.Globalization;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Implementations;

public sealed class MarkdownBundleWriter : IBundleWriter
{
    private readonly ISecretMasker _masker;
    public MarkdownBundleWriter(ISecretMasker masker) => _masker = masker;

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
                // Read with UTF-8 to avoid encoding issues
                content = File.ReadAllText(f.FullPath, Encoding.UTF8);
                if (settings.MaskSecrets) content = _masker.Process(f.RelativePath, content);
            }
            catch
            {
                content = $"/* FEHLER: Datei konnte nicht gelesen werden: {f.FullPath} */";
            }

            sb.AppendLine(content);
            sb.AppendLine("```");
        }

        // Determine output filename: prefer explicit filename; if default/empty use solution name
        var filename = settings.OutputFileName;
        var defaultName = "Bundle.md";
        if (string.IsNullOrWhiteSpace(filename) || string.Equals(filename, defaultName, StringComparison.OrdinalIgnoreCase))
        {
            var baseName = Path.GetFileNameWithoutExtension(info.SolutionName) ?? "Solution";
            filename = baseName + ".md";
        }
        else if (!Path.HasExtension(filename))
        {
            filename = filename + ".md";
        }

        var outputPath = Path.Combine(root, filename);
        File.WriteAllText(outputPath, sb.ToString(), Encoding.UTF8);
        return outputPath;

        static string ToAnchor(string rel)
        {
            if (string.IsNullOrEmpty(rel)) return string.Empty;

            // Normalize and remove diacritics
            var s = rel.Replace('\\', '/');
            s = s.Normalize(NormalizationForm.FormD);

            // handle special German sharp s
            s = s.Replace('\u00DF', 's'); // small workaround; will be normalized further

            var sb = new StringBuilder(s.Length);
            foreach (var ch in s)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc == UnicodeCategory.NonSpacingMark) continue;

                // allow ASCII letters and digits
                if (ch >= 'A' && ch <= 'Z' || ch >= 'a' && ch <= 'z' || ch >= '0' && ch <= '9')
                {
                    sb.Append(char.ToLowerInvariant(ch));
                    continue;
                }

                // treat common separators as hyphen
                if (ch == '/' || ch == ' ' || ch == '-' || ch == '_' || ch == '.' || ch == ':')
                {
                    sb.Append('-');
                    continue;
                }

                // ignore other characters (non-ascii)
            }

            // collapse multiple hyphens
            var result = System.Text.RegularExpressions.Regex.Replace(sb.ToString(), "-+", "-");
            result = result.Trim('-');
            return result;
        }
    }
}
```

## SolutionBundler.Core/Implementations/MsBuildProjectMetadataReader.cs
_size_: 2684 bytes - _sha1_: ed42e686526d5e8ca1b4d5ff664e2f329635db0b - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/MsBuildProjectMetadataReader.cs | HASH: ed42e686526d5e8ca1b4d5ff664e2f329635db0b | ACTION: Compile ---
```csharp
using System.Xml.Linq;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Implementations;

public sealed class MsBuildProjectMetadataReader : IProjectMetadataReader
{
    public void EnrichBuildActions(IList<FileEntry> entries, string rootPath)
    {
        // einfache Heuristik: aus allen csproj BuildActions lesen und auf Eintr�ge mappen
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
```

## SolutionBundler.Core/Implementations/RegexSecretMasker.cs
_size_: 827 bytes - _sha1_: c481aed48453f5e5e82d98e29fd1a2b0badc936d - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/RegexSecretMasker.cs | HASH: c481aed48453f5e5e82d98e29fd1a2b0badc936d | ACTION: Compile ---
```csharp
using System.Text.RegularExpressions;
using SolutionBundler.Core.Abstractions;

namespace SolutionBundler.Core.Implementations;

public sealed class RegexSecretMasker : ISecretMasker
{
    // einfache Heuristik: maskiert typische Keys in JSON/Config
    static readonly Regex KeyValue =
        new(@"(?i)(""?(password|apikey|api_key|connectionstring|secret|token)""?\s*[:=]\s*""?).+?(""|\r?\n)",
            RegexOptions.Compiled);

    public string Process(string relativePath, string content)
    {
        if (!relativePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase) &&
            !relativePath.EndsWith(".config", StringComparison.OrdinalIgnoreCase))
            return content;

        return KeyValue.Replace(content, m => $"{m.Groups[1].Value}***MASKED***{m.Groups[3].Value}");
    }
}
```

## SolutionBundler.Core/Implementations/Sha1HashCalculator.cs
_size_: 499 bytes - _sha1_: ca4b7d19552478fc943ec45ee018845b1320cf5b - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/Sha1HashCalculator.cs | HASH: ca4b7d19552478fc943ec45ee018845b1320cf5b | ACTION: Compile ---
```csharp
using System.Security.Cryptography;
using System.Text;
using SolutionBundler.Core.Abstractions;

namespace SolutionBundler.Core.Implementations;

public sealed class Sha1HashCalculator : IHashCalculator
{
    public string Sha1(byte[] bytes)
    {
        using var sha1 = SHA1.Create();
        var hash = sha1.ComputeHash(bytes);
        var sb = new StringBuilder(hash.Length * 2);
        foreach (var b in hash) sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}
```

## SolutionBundler.Core/Implementations/SimpleContentClassifier.cs
_size_: 568 bytes - _sha1_: 578abfd6753e0a5122be15d37265264937c3f584 - _action_: Compile

--- FILE: SolutionBundler.Core/Implementations/SimpleContentClassifier.cs | HASH: 578abfd6753e0a5122be15d37265264937c3f584 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Abstractions;

namespace SolutionBundler.Core.Implementations;

public sealed class SimpleContentClassifier : IContentClassifier
{
    public string Classify(string filePath)
    {
        var ext = Path.GetExtension(filePath).ToLowerInvariant();
        return ext switch
        {
            ".cs" => "csharp",
            ".xaml" => "xaml",
            ".csproj" or ".props" or ".targets" or ".resx" or ".config" => "xml",
            ".json" => "json",
            ".sln" => "",
            _ => ""
        };
    }
}
```

## SolutionBundler.Core/Models/BuildAction.cs
_size_: 153 bytes - _sha1_: 26eb857d3a578020d5551cab378f2b0d71742b1b - _action_: Compile

--- FILE: SolutionBundler.Core/Models/BuildAction.cs | HASH: 26eb857d3a578020d5551cab378f2b0d71742b1b | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core.Models;

public enum BuildAction
{
    Unknown = 0,
    Compile,
    Page,
    Resource,
    Content,
    None
}
```

## SolutionBundler.Core/Models/FileEntry.cs
_size_: 419 bytes - _sha1_: 351a0df5839a6a0af397aa5aba8736ebc934cc1c - _action_: Compile

--- FILE: SolutionBundler.Core/Models/FileEntry.cs | HASH: 351a0df5839a6a0af397aa5aba8736ebc934cc1c | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Models;

public sealed class FileEntry
{
    public required string RelativePath { get; init; }
    public required string FullPath { get; init; }
    public long Size { get; set; }
    public string Sha1 { get; set; } = "";
    public string Language { get; set; } = "";
    public BuildAction Action { get; set; } = BuildAction.Unknown;
}
```

## SolutionBundler.Core/Models/ScanSettings.cs
_size_: 745 bytes - _sha1_: 77d267b398e38549e64581cf9d9be8b8f47f884e - _action_: Compile

--- FILE: SolutionBundler.Core/Models/ScanSettings.cs | HASH: 77d267b398e38549e64581cf9d9be8b8f47f884e | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core.Models;

public sealed class ScanSettings
{
    public string[] IncludePatterns { get; init; } =
    {
        "*.sln","*.csproj","*.props","*.targets","*.cs","*.xaml","*.resx",
        "*.config","*.json",".editorconfig","app.manifest","Directory.Build.props","Directory.Build.targets","Directory.Packages.props"
    };

    public string[] ExcludeDirs { get; init; } = { "bin","obj",".git",".vs","node_modules" };

    public string[] ExcludeGlobs { get; init; } = { "*.g.cs","*.designer.cs","*.user","*.pfx","*.pem" };

    public bool MaskSecrets { get; init; } = true;

    public bool SplitByProject { get; init; } = false;

    public string OutputFileName { get; init; } = "Bundle.md";
}
```

## SolutionBundler.Core/Models/SolutionInfo.cs
_size_: 342 bytes - _sha1_: 0fbcfe74e594ace61ec50379f25a439377ac09dc - _action_: Compile

--- FILE: SolutionBundler.Core/Models/SolutionInfo.cs | HASH: 0fbcfe74e594ace61ec50379f25a439377ac09dc | ACTION: Compile ---
```csharp
namespace SolutionBundler.Core.Models;

public sealed class SolutionInfo
{
    public required string RootPath { get; init; }
    public required string SolutionName { get; init; }
    public DateTime GeneratedAt { get; init; } = DateTime.Now;
    public string DotnetHint { get; init; } = "Bitte .NET SDK Version in README pr�fen";
}
```

## SolutionBundler.Core/ServiceCollectionExtensions.cs
_size_: 988 bytes - _sha1_: 7fcbde37c89818c4afec2f8b29799636d8f44699 - _action_: Compile

--- FILE: SolutionBundler.Core/ServiceCollectionExtensions.cs | HASH: 7fcbde37c89818c4afec2f8b29799636d8f44699 | ACTION: Compile ---
```csharp
using Microsoft.Extensions.DependencyInjection;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Implementations;

namespace SolutionBundler.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionBundlerCore(this IServiceCollection services)
    {
        services.AddSingleton<IFileScanner, DefaultFileScanner>();
        services.AddSingleton<IProjectMetadataReader, MsBuildProjectMetadataReader>();
        services.AddSingleton<IContentClassifier, SimpleContentClassifier>();
        services.AddSingleton<IHashCalculator, Sha1HashCalculator>();
        services.AddSingleton<ISecretMasker, RegexSecretMasker>();
        services.AddSingleton<IBundleWriter, MarkdownBundleWriter>(sp => new MarkdownBundleWriter(sp.GetRequiredService<ISecretMasker>()));
        services.AddSingleton<IBundleOrchestrator, SolutionBundler.Core.Implementations.BundleOrchestrator>();
        return services;
    }
}
```

## SolutionBundler.Core/SolutionBundler.Core.csproj
_size_: 332 bytes - _sha1_: e9ea2e69f7c989002d9125c7dd4630910640a0f6 - _action_: Unknown

--- FILE: SolutionBundler.Core/SolutionBundler.Core.csproj | HASH: e9ea2e69f7c989002d9125c7dd4630910640a0f6 | ACTION: Unknown ---
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <GenerateDocumentationFile>false</GenerateDocumentationFile>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
  </ItemGroup>

</Project>

```

## SolutionBundler.sln
_size_: 4634 bytes - _sha1_: fde7ca6ed33eb3da8927265604a17bd45f41deec - _action_: Unknown

--- FILE: SolutionBundler.sln | HASH: fde7ca6ed33eb3da8927265604a17bd45f41deec | ACTION: Unknown ---
```

Microsoft Visual Studio Solution File, Format Version 12.00
# Visual Studio Version 17
VisualStudioVersion = 17.0.31903.59
MinimumVisualStudioVersion = 10.0.40219.1
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "SolutionBundler.WPF", "SolutionBundler.WPF\SolutionBundler.WPF.csproj", "{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "SolutionBundler.Core", "SolutionBundler.Core\SolutionBundler.Core.csproj", "{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}"
EndProject
Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "SolutionBundler.Tests", "SolutionBundler.Tests\SolutionBundler.Tests.csproj", "{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Projekt", "Projekt", "{02EA681E-C7D8-13C7-8484-4AC65E1B71E8}"
EndProject
Project("{2150E333-8FDC-42A3-9474-1A3956D46DE8}") = "Tests", "Tests", "{6A3B02A6-6D95-4B81-AB85-3446933A0766}"
EndProject
Global
	GlobalSection(SolutionConfigurationPlatforms) = preSolution
		Debug|Any CPU = Debug|Any CPU
		Debug|x64 = Debug|x64
		Debug|x86 = Debug|x86
		Release|Any CPU = Release|Any CPU
		Release|x64 = Release|x64
		Release|x86 = Release|x86
	EndGlobalSection
	GlobalSection(ProjectConfigurationPlatforms) = postSolution
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Debug|x64.ActiveCfg = Debug|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Debug|x64.Build.0 = Debug|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Debug|x86.ActiveCfg = Debug|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Debug|x86.Build.0 = Debug|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Release|Any CPU.Build.0 = Release|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Release|x64.ActiveCfg = Release|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Release|x64.Build.0 = Release|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Release|x86.ActiveCfg = Release|Any CPU
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA}.Release|x86.Build.0 = Release|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Debug|x64.ActiveCfg = Debug|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Debug|x64.Build.0 = Debug|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Debug|x86.ActiveCfg = Debug|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Debug|x86.Build.0 = Debug|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Release|Any CPU.Build.0 = Release|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Release|x64.ActiveCfg = Release|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Release|x64.Build.0 = Release|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Release|x86.ActiveCfg = Release|Any CPU
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5}.Release|x86.Build.0 = Release|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Debug|Any CPU.ActiveCfg = Debug|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Debug|Any CPU.Build.0 = Debug|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Debug|x64.ActiveCfg = Debug|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Debug|x64.Build.0 = Debug|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Debug|x86.ActiveCfg = Debug|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Debug|x86.Build.0 = Debug|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Release|Any CPU.ActiveCfg = Release|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Release|Any CPU.Build.0 = Release|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Release|x64.ActiveCfg = Release|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Release|x64.Build.0 = Release|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Release|x86.ActiveCfg = Release|Any CPU
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A}.Release|x86.Build.0 = Release|Any CPU
	EndGlobalSection
	GlobalSection(SolutionProperties) = preSolution
		HideSolutionNode = FALSE
	EndGlobalSection
	GlobalSection(NestedProjects) = preSolution
		{BBA8EE23-D707-4BC5-970A-2F590BB1D2DA} = {02EA681E-C7D8-13C7-8484-4AC65E1B71E8}
		{15AFAC20-6D6D-4753-A9DF-3590283B1BA5} = {02EA681E-C7D8-13C7-8484-4AC65E1B71E8}
		{E250B7ED-AB06-4267-86D3-D5BAE0D2929A} = {6A3B02A6-6D95-4B81-AB85-3446933A0766}
	EndGlobalSection
EndGlobal

```

## SolutionBundler.Tests/DefaultFileScannerTests.cs
_size_: 933 bytes - _sha1_: f147d457532a32906dab8cea9a024374de57740c - _action_: Compile

--- FILE: SolutionBundler.Tests/DefaultFileScannerTests.cs | HASH: f147d457532a32906dab8cea9a024374de57740c | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Implementations;
using SolutionBundler.Core.Models;
using Xunit;

namespace SolutionBundler.Tests;

public class DefaultFileScannerTests
{
    [Fact]
    public void Scan_Returns_ExpectedFiles_In_RepoRoot()
    {
        var root = Directory.GetCurrentDirectory();
        while (!File.Exists(Path.Combine(root, "SolutionBundler.sln")))
        {
            var parent = Directory.GetParent(root);
            if (parent is null) break;
            root = parent.FullName;
        }

        var scanner = new DefaultFileScanner();
        var settings = new ScanSettings();
        var files = scanner.Scan(root, settings);

        Assert.NotNull(files);
        Assert.Contains(files, f => f.RelativePath.EndsWith("SolutionBundler.sln", StringComparison.OrdinalIgnoreCase) || f.RelativePath.EndsWith("SolutionBundler.Core.csproj", StringComparison.OrdinalIgnoreCase));
    }
}
```

## SolutionBundler.Tests/HashAndClassifierTests.cs
_size_: 812 bytes - _sha1_: 4a9a965f651825d9bb55a2ec4b76d4bd9942449d - _action_: Compile

--- FILE: SolutionBundler.Tests/HashAndClassifierTests.cs | HASH: 4a9a965f651825d9bb55a2ec4b76d4bd9942449d | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Implementations;
using Xunit;

namespace SolutionBundler.Tests;

public class HashAndClassifierTests
{
    [Fact]
    public void Sha1HashCalculator_Produces_ExpectedLength()
    {
        var hasher = new Sha1HashCalculator();
        var hash = hasher.Sha1(System.Text.Encoding.UTF8.GetBytes("hello"));
        Assert.Equal(40, hash.Length);
    }

    [Theory]
    [InlineData("file.cs", "csharp")]
    [InlineData("view.xaml", "xaml")]
    [InlineData("project.csproj", "xml")]
    [InlineData("data.json", "json")]
    [InlineData("solution.sln", "")]
    public void Classifier_Returns_Expected(string path, string expected)
    {
        var classifier = new SimpleContentClassifier();
        Assert.Equal(expected, classifier.Classify(path));
    }
}
```

## SolutionBundler.Tests/MsBuildProjectMetadataReaderTests.cs
_size_: 992 bytes - _sha1_: 269ad34eff2c7d5f480a3ade51d21084bfd1aefe - _action_: Compile

--- FILE: SolutionBundler.Tests/MsBuildProjectMetadataReaderTests.cs | HASH: 269ad34eff2c7d5f480a3ade51d21084bfd1aefe | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Implementations;
using SolutionBundler.Core.Models;
using Xunit;

namespace SolutionBundler.Tests;

public class MsBuildProjectMetadataReaderTests
{
    [Fact]
    public void EnrichBuildActions_Sets_Action_For_CS_Fallback()
    {
        var entries = new List<SolutionBundler.Core.Models.FileEntry>
        {
            new() { RelativePath = "src/Program.cs", FullPath = "src/Program.cs", Size = 0 },
            new() { RelativePath = "views/MainWindow.xaml", FullPath = "views/MainWindow.xaml", Size = 0 }
        };

        var reader = new MsBuildProjectMetadataReader();
        reader.EnrichBuildActions(entries, Directory.GetCurrentDirectory());

        Assert.Equal(SolutionBundler.Core.Models.BuildAction.Compile, entries.First(e => e.RelativePath.EndsWith("Program.cs")).Action);
        Assert.Equal(SolutionBundler.Core.Models.BuildAction.Page, entries.First(e => e.RelativePath.EndsWith("MainWindow.xaml")).Action);
    }
}
```

## SolutionBundler.Tests/RegexSecretMaskerTests.cs
_size_: 729 bytes - _sha1_: c0ad72004c2d281d4d8b1e7e6fd31223f1dfa1e7 - _action_: Compile

--- FILE: SolutionBundler.Tests/RegexSecretMaskerTests.cs | HASH: c0ad72004c2d281d4d8b1e7e6fd31223f1dfa1e7 | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Implementations;
using Xunit;

namespace SolutionBundler.Tests;

public class RegexSecretMaskerTests
{
    [Fact]
    public void MasksJsonSecrets()
    {
        var masker = new RegexSecretMasker();
        var input = "{\"apiKey\": \"12345\", \"other\": \"x\"}\n";
        var outp = masker.Process("appsettings.json", input);
        Assert.DoesNotContain("12345", outp);
        Assert.Contains("***MASKED***", outp);
    }

    [Fact]
    public void LeavesNonJsonUnchanged()
    {
        var masker = new RegexSecretMasker();
        var input = "password=secretvalue";
        var outp = masker.Process("secrets.txt", input);
        Assert.Equal(input, outp);
    }
}
```

## SolutionBundler.Tests/SmokeTests.cs
_size_: 738 bytes - _sha1_: 29d9db8459b465180e0d2bdecdce7e5d9f25c25c - _action_: Compile

--- FILE: SolutionBundler.Tests/SmokeTests.cs | HASH: 29d9db8459b465180e0d2bdecdce7e5d9f25c25c | ACTION: Compile ---
```csharp
using SolutionBundler.Core.Implementations;
using SolutionBundler.Core.Models;
using Xunit;

namespace SolutionBundler.Tests;

public class SmokeTests
{
    [Fact]
    public void Scanner_Returns_SomeFiles_On_Self()
    {
        var root = Directory.GetCurrentDirectory();
        while (!File.Exists(Path.Combine(root, "SolutionBundler.sln")))
        {
            var parent = Directory.GetParent(root);
            if (parent is null) break;
            root = parent.FullName;
        }

        var scanner = new DefaultFileScanner();
        var settings = new ScanSettings();
        var files = scanner.Scan(root, settings);

        Assert.NotNull(files);
        Assert.True(files.Count > 0);
    }
}
```

## SolutionBundler.Tests/SolutionBundler.Tests.csproj
_size_: 708 bytes - _sha1_: beab1e8a33c5b1c5fb493b4c3aaa052b55feab45 - _action_: Unknown

--- FILE: SolutionBundler.Tests/SolutionBundler.Tests.csproj | HASH: beab1e8a33c5b1c5fb493b4c3aaa052b55feab45 | ACTION: Unknown ---
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>
    <IsPackable>false</IsPackable>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.11.1" />
    <PackageReference Include="xunit" Version="2.9.2" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.8.2">
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
      <PrivateAssets>all</PrivateAssets>
    </PackageReference>
  </ItemGroup>

  <ItemGroup>
    <ProjectReference Include="..\SolutionBundler.Core\SolutionBundler.Core.csproj" />
  </ItemGroup>

</Project>

```

## SolutionBundler.Tests/UnitTest1.cs
_size_: 130 bytes - _sha1_: 9c9321b6a3f2d4db1e1fa6aa2d128ad779f80c80 - _action_: Compile

--- FILE: SolutionBundler.Tests/UnitTest1.cs | HASH: 9c9321b6a3f2d4db1e1fa6aa2d128ad779f80c80 | ACTION: Compile ---
```csharp
namespace SolutionBundler.Tests;

public class UnitTest1
{
    // removed default generated test to rely on SmokeTests only
}
```

## SolutionBundler.WPF/App.xaml
_size_: 290 bytes - _sha1_: cea15223028593ab6389f35d8e1fd3de9154a6b1 - _action_: Page

--- FILE: SolutionBundler.WPF/App.xaml | HASH: cea15223028593ab6389f35d8e1fd3de9154a6b1 | ACTION: Page ---
```xaml
<Application x:Class="SolutionBundler.WPF.App"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             StartupUri="MainWindow.xaml">
    <Application.Resources/>
</Application>

```

## SolutionBundler.WPF/App.xaml.cs
_size_: 125 bytes - _sha1_: 1d37facd1952d6a2f437eb00eb2e442d92e24b66 - _action_: Compile

--- FILE: SolutionBundler.WPF/App.xaml.cs | HASH: 1d37facd1952d6a2f437eb00eb2e442d92e24b66 | ACTION: Compile ---
```csharp
using System.Windows;

namespace SolutionBundler.WPF;

public partial class App : System.Windows.Application
{
}


```

## SolutionBundler.WPF/AssemblyInfo.cs
_size_: 643 bytes - _sha1_: cf7b896074f026f67130b4b23a0780f865e2ccf5 - _action_: Compile

--- FILE: SolutionBundler.WPF/AssemblyInfo.cs | HASH: cf7b896074f026f67130b4b23a0780f865e2ccf5 | ACTION: Compile ---
```csharp
using System.Windows;

[assembly:ThemeInfo(
    ResourceDictionaryLocation.None,            //where theme specific resource dictionaries are located
                                                //(used if a resource is not found in the page,
                                                // or application resource dictionaries)
    ResourceDictionaryLocation.SourceAssembly   //where the generic resource dictionary is located
                                                //(used if a resource is not found in the page,
                                                // app, or any theme specific resource dictionaries)
)]

```

## SolutionBundler.WPF/MainWindow.xaml
_size_: 1781 bytes - _sha1_: 9acfe8017e26f799fca3c1511b04949dc07cbaa8 - _action_: Page

--- FILE: SolutionBundler.WPF/MainWindow.xaml | HASH: 9acfe8017e26f799fca3c1511b04949dc07cbaa8 | ACTION: Page ---
```xaml
<Window x:Class="SolutionBundler.WPF.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Solution Bundler" Height="420" Width="720"
        WindowStartupLocation="CenterScreen">
    <Grid Margin="16">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
            <RowDefinition Height="Auto" />
        </Grid.RowDefinitions>

        <TextBlock Text="Root-Verzeichnis (enthält die .sln):" FontWeight="Bold"/>
        <StackPanel Orientation="Horizontal" Margin="0,8,0,8" Grid.Row="1">
            <TextBox x:Name="RootBox" MinWidth="520" Margin="0,0,8,0"/>
            <Button Content="Ordner wählen…" Click="Browse_Click"/>
        </StackPanel>

        <GroupBox Header="Optionen" Grid.Row="2">
            <StackPanel Margin="8">
                <CheckBox x:Name="ChkMask" Content="Secrets maskieren (JSON/Config)" IsChecked="True"/>
                <TextBlock Text="Ausgabedatei:" Margin="0,8,0,4"/>
                <TextBox x:Name="OutputName" Text="Bundle.md" MinWidth="240"/>
                <ProgressBar x:Name="Prog" Height="16" Margin="0,12,0,0" Minimum="0" Maximum="100" Value="0"/>
                <TextBlock x:Name="StatusText" Margin="0,6,0,0" Text="Bereit."/>
            </StackPanel>
        </GroupBox>

        <StackPanel Orientation="Horizontal" Grid.Row="3" HorizontalAlignment="Right">
            <Button Content="Scan &amp; Bundle" Margin="0,12,8,0" Click="Run_Click"/>
            <Button Content="Öffnen" Margin="0,12,0,0" Click="Open_Click"/>
        </StackPanel>
    </Grid>
</Window>

```

## SolutionBundler.WPF/MainWindow.xaml.cs
_size_: 4194 bytes - _sha1_: 22ee5e10e4ef78115c197f16d36b4e0f25bb8a72 - _action_: Compile

--- FILE: SolutionBundler.WPF/MainWindow.xaml.cs | HASH: 22ee5e10e4ef78115c197f16d36b4e0f25bb8a72 | ACTION: Compile ---
```csharp
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Implementations;
using SolutionBundler.Core.Models;
using System;

namespace SolutionBundler.WPF;

public partial class MainWindow : Window
{
    private readonly IBundleOrchestrator _orchestrator;
    private string? _lastOutput;

    public MainWindow()
    {
        InitializeComponent();

        // Einfache "manuelle DI"
        var scanner = new DefaultFileScanner();
        var meta = new MsBuildProjectMetadataReader();
        var classifier = new SimpleContentClassifier();
        var hasher = new Sha1HashCalculator();
        var masker = new RegexSecretMasker();
        var writer = new MarkdownBundleWriter(masker);
        _orchestrator = new BundleOrchestrator(scanner, meta, classifier, hasher, writer);
    }

    private void Browse_Click(object sender, RoutedEventArgs e)
    {
        using var dlg = new FolderBrowserDialog();
        dlg.Description = "Ordner wählen, der die .sln-Datei enthält";
        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            RootBox.Text = dlg.SelectedPath;

            // Wenn der Nutzer keinen eigenen Ausgabename gesetzt hat (oder Standard),
            // setzen wir vorgeschlagenen Dateinamen auf <SolutionName>.md
            var current = OutputName.Text;
            if (string.IsNullOrWhiteSpace(current) || string.Equals(current, "Bundle.md", System.StringComparison.OrdinalIgnoreCase))
            {
                var sln = Directory.EnumerateFiles(dlg.SelectedPath, "*.sln", SearchOption.TopDirectoryOnly)
                                   .Select(Path.GetFileNameWithoutExtension)
                                   .FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(sln))
                {
                    OutputName.Text = sln + ".md";
                }
            }
        }
    }

    private async void Run_Click(object sender, RoutedEventArgs e)
    {
        var root = RootBox.Text;
        if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root))
        {
            System.Windows.MessageBox.Show("Bitte ein gültiges Root-Verzeichnis wählen.");
            return;
        }

        var slnExists = Directory.EnumerateFiles(root, "*.sln", SearchOption.TopDirectoryOnly).Any();
        if (!slnExists)
        {
            System.Windows.MessageBox.Show("Im gewählten Ordner wurde keine .sln gefunden.");
            return;
        }

        try
        {
            IsEnabled = false;
            StatusText.Text = "Scanne und erstelle Bundle…";

            // create progress that posts back to UI thread
            Prog.Value = 0;
            var progress = new Progress<int>(value =>
            {
                // clamp and set
                if (value < 0) value = 0;
                if (value > 100) value = 100;
                Prog.Value = value;
            });

            var settings = new ScanSettings
            {
                MaskSecrets = ChkMask.IsChecked == true,
                OutputFileName = string.IsNullOrWhiteSpace(OutputName.Text) ? "Bundle.md" : OutputName.Text
            };

            _lastOutput = await Task.Run(() => _orchestrator.Run(root, settings, progress));

            Prog.Value = 100;
            StatusText.Text = $"Fertig: {_lastOutput}";
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show("Fehler: " + ex.Message);
            StatusText.Text = "Fehler.";
        }
        finally
        {
            IsEnabled = true;
        }
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_lastOutput) && File.Exists(_lastOutput))
        {
            Process.Start(new ProcessStartInfo { FileName = _lastOutput, UseShellExecute = true });
        }
        else
        {
            System.Windows.MessageBox.Show("Es liegt noch kein Ergebnis vor.");
        }
    }
}
```

## SolutionBundler.WPF/SolutionBundler.WPF.csproj
_size_: 378 bytes - _sha1_: b93b107e728959b59747bbc27cd4d7bce2a8d222 - _action_: Unknown

--- FILE: SolutionBundler.WPF/SolutionBundler.WPF.csproj | HASH: b93b107e728959b59747bbc27cd4d7bce2a8d222 | ACTION: Unknown ---
```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>WinExe</OutputType>
    <TargetFramework>net8.0-windows</TargetFramework>
    <UseWPF>true</UseWPF>
    <UseWindowsForms>true</UseWindowsForms>
  </PropertyGroup>

  <ItemGroup>
    <ProjectReference Include="..\SolutionBundler.Core\SolutionBundler.Core.csproj" />
  </ItemGroup>

</Project>

```
