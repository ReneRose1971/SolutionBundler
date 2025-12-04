using System.IO;
using System.Xml.Linq;
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

        bool IsUnderAnyDir(string filePath, HashSet<string> dirs)
        {
            foreach (var d in dirs)
            {
                if (filePath.StartsWith(d + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) ||
                    string.Equals(filePath, d, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        bool IsTestProjectByPath(string filePath)
        {
            var rel = Path.GetRelativePath(root, filePath).Replace('\\','/');
            if (rel.IndexOf("/test/", StringComparison.OrdinalIgnoreCase) >= 0) return true;
            if (rel.IndexOf("/tests/", StringComparison.OrdinalIgnoreCase) >= 0) return true;
            var name = Path.GetFileName(filePath);
            if (name.IndexOf(".test", StringComparison.OrdinalIgnoreCase) >= 0) return true;
            if (name.IndexOf(".tests", StringComparison.OrdinalIgnoreCase) >= 0) return true;
            return false;
        }

        bool IsTestProjectByCsproj(string csprojPath)
        {
            try
            {
                var doc = XDocument.Load(csprojPath);
                // check IsTestProject element
                var isTest = doc.Descendants().FirstOrDefault(e => string.Equals(e.Name.LocalName, "IsTestProject", StringComparison.OrdinalIgnoreCase));
                if (isTest != null && bool.TryParse(isTest.Value.Trim(), out var v) && v) return true;

                // check PackageReference includes for common test packages
                var pkgRefs = doc.Descendants().Where(e => string.Equals(e.Name.LocalName, "PackageReference", StringComparison.OrdinalIgnoreCase));
                foreach (var pr in pkgRefs)
                {
                    var include = pr.Attribute("Include")?.Value ?? pr.Attribute("Update")?.Value ?? string.Empty;
                    if (string.IsNullOrWhiteSpace(include)) continue;
                    var inc = include.ToLowerInvariant();
                    if (inc.Contains("microsoft.net.test.sdk") || inc.Contains("xunit") || inc.Contains("nunit") || inc.Contains("mstest"))
                        return true;
                }

                // also check for Reference to test SDK
                var sdk = doc.Root?.Attribute("Sdk")?.Value;
                if (!string.IsNullOrWhiteSpace(sdk) && sdk.ToLowerInvariant().Contains("microsoft.net.sdk.tests")) return true;
            }
            catch
            {
                // ignore parse errors and fallback to path-based heuristics
            }

            return false;
        }

        // First collect directories of identified test projects
        var testProjectDirs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        try
        {
            foreach (var csproj in Directory.EnumerateFiles(root, "*.csproj", SearchOption.AllDirectories))
            {
                var full = Path.GetFullPath(csproj);
                if (IsTestProjectByPath(full) || IsTestProjectByCsproj(full))
                {
                    var projDir = Path.GetDirectoryName(full) ?? full;
                    testProjectDirs.Add(projDir);
                }
            }
        }
        catch
        {
            // if enumeration fails, proceed without test-project dir filtering
        }

        foreach (var pattern in settings.IncludePatterns)
        {
            foreach (var file in Directory.EnumerateFiles(root, pattern, SearchOption.AllDirectories))
            {
                var full = Path.GetFullPath(file);
                if (IsExcludedDir(full) || IsExcludedFile(full)) continue;

                // skip files that are under detected test project directories
                if (IsUnderAnyDir(full, testProjectDirs)) continue;

                // also skip csproj files that by path heuristics look like tests
                if (full.EndsWith(".csproj", StringComparison.OrdinalIgnoreCase) && IsTestProjectByPath(full)) continue;

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