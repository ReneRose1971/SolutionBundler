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