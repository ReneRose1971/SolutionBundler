using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Models;

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

    public string Run(string rootPath, ScanSettings settings)
    {
        var files = _scanner.Scan(rootPath, settings).ToList();

        // Hash + Language
        foreach (var f in files)
        {
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
        }

        _metadata.EnrichBuildActions(files, rootPath);

        var slnName = Directory.EnumerateFiles(rootPath, "*.sln", SearchOption.TopDirectoryOnly)
                               .Select(Path.GetFileName)
                               .FirstOrDefault() ?? "Solution";

        var info = new SolutionInfo
        {
            RootPath = rootPath,
            SolutionName = slnName
        };

        return _writer.Write(info, files, settings);
    }
}