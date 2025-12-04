using System.Security.Cryptography;
using System.Text;
using SolutionBundler.Core.Abstractions;

namespace SolutionBundler.Core.Implementations;

public sealed class Sha1HashCalculator : IHashCalculator
{
    public string Sha1(byte[] bytes)
    {
        using var sha1 = SHA1.Create();
        var hash = sha1.ComputeHash(bytes);
        var sb = new StringBuilder(hash.Length * 2);
        foreach (var b in hash) sb.Append(b.ToString("x2"));
        return sb.ToString();
    }
}