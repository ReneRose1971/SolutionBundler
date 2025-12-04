namespace SolutionBundler.Core.Abstractions;

public interface IHashCalculator
{
    string Sha1(byte[] bytes);
}