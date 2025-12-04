namespace SolutionBundler.Core.Abstractions;

public interface IContentClassifier
{
    string Classify(string filePath);
}