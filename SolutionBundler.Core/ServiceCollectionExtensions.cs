using Microsoft.Extensions.DependencyInjection;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Implementations;

namespace SolutionBundler.Core;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSolutionBundlerCore(this IServiceCollection services)
    {
        services.AddSingleton<IFileScanner, DefaultFileScanner>();
        services.AddSingleton<IProjectMetadataReader, MsBuildProjectMetadataReader>();
        services.AddSingleton<IContentClassifier, SimpleContentClassifier>();
        services.AddSingleton<IHashCalculator, Sha1HashCalculator>();
        services.AddSingleton<ISecretMasker, RegexSecretMasker>();
        services.AddSingleton<IBundleWriter, MarkdownBundleWriter>(sp => new MarkdownBundleWriter(sp.GetRequiredService<ISecretMasker>()));
        services.AddSingleton<IBundleOrchestrator, SolutionBundler.Core.Implementations.BundleOrchestrator>();
        return services;
    }
}