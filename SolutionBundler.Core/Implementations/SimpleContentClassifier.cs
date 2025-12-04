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