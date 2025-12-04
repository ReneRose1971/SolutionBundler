using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IBundleWriter
{
    string Write(SolutionInfo info, IEnumerable<FileEntry> files, ScanSettings settings);
}