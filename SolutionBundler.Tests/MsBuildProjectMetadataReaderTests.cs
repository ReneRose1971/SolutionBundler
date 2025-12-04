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