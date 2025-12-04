using SolutionBundler.Core.Models;

namespace SolutionBundler.Core.Abstractions;

/// <summary>
/// Schreibt ein Bundle aus den gesammelten Informationen in eine Datei.
/// </summary>
public interface IBundleWriter
{
    /// <summary>
    /// Schreibt das Bundle für die angegebene Solution-Info und die Dateiliste.
    /// </summary>
    /// <param name="info">Metadaten zur Solution (Root-Pfad, Name, etc.).</param>
    /// <param name="files">Sammlung von Dateieinträgen, die in das Bundle aufgenommen werden sollen.</param>
    /// <param name="settings">Scan- und Ausgabe-Einstellungen.</param>
    /// <returns>Pfad zur erzeugten Bundle-Datei.</returns>
    string Write(SolutionInfo info, IEnumerable<FileEntry> files, ScanSettings settings);
}