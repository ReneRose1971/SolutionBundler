using System.Text.RegularExpressions;
using SolutionBundler.Core.Abstractions;

namespace SolutionBundler.Core.Implementations;

public sealed class RegexSecretMasker : ISecretMasker
{
    // einfache Heuristik: maskiert typische Keys in JSON/Config
    static readonly Regex KeyValue =
        new(@"(?i)(""?(password|apikey|api_key|connectionstring|secret|token)""?\s*[:=]\s*""?).+?(""|\r?\n)",
            RegexOptions.Compiled);

    public string Process(string relativePath, string content)
    {
        if (!relativePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase) &&
            !relativePath.EndsWith(".config", StringComparison.OrdinalIgnoreCase))
            return content;

        return KeyValue.Replace(content, m => $"{m.Groups[1].Value}***MASKED***{m.Groups[3].Value}");
    }
}