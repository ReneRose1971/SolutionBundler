using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

public interface IBundleOrchestrator
{
    string Run(string rootPath, ScanSettings settings);
}