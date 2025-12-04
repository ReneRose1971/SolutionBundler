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