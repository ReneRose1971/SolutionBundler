using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IProjectMetadataReader
{
    void EnrichBuildActions(IList<FileEntry> entries, string rootPath);
}