namespace SolutionBundler.Core.Abstractions;

public interface ISecretMasker
{
    string Process(string relativePath, string content);
}