using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IFileScanner
{
    IReadOnlyList<FileEntry> Scan(string rootPath, ScanSettings settings);
}