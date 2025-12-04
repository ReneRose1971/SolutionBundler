# Workflow: SolutionBundler

Dieses Dokument folgt dem Benutzer-Workflow und erklärt, welche Klassen beteiligt sind, welche Aufgaben sie übernehmen und in welcher Reihenfolge sie verwendet werden. Ziel ist sowohl eine Betriebsanleitung als auch eine Entwickler-Map des Ausführungspfades.

Übersicht des Workflows

1. Solution-Datei wählen (UI)
   - Das WPF-`MainWindow` ist der Einstiegspunkt für den Nutzer. Der Nutzer wählt einen Ordner, der eine `.sln`-Datei enthält.
   - `MainWindow` erzeugt und konfiguriert einen `IBundleOrchestrator` (derzeit manuelle DI) und ruft ihn auf.

2. Scan ausführen
   - `BundleOrchestrator.Run` ist der Orchestrator-Einstiegspunkt für Scan und Bundle-Erstellung.
   - `DefaultFileScanner` durchsucht das angegebene Root-Verzeichnis gemäß `ScanSettings`.
     - Ausschluss von konfigurierten Verzeichnissen und Globs.
     - Erkennung und Überspringen von Testprojekten durch Analyse der `.csproj`-Inhalte und gängiger Namensmuster.
   - Für jede gefundene Datei berechnet der Orchestrator eine SHA1-Prüfsumme mittels `Sha1HashCalculator` und klassifiziert die Sprache über `SimpleContentClassifier`.
   - `MsBuildProjectMetadataReader` ergänzt Dateieinträge mit `BuildAction`-Werten, welche aus den `.csproj` `ItemGroup`-Einträgen gelesen werden.

3. Markdown-Bundle erstellen und speichern
   - `MarkdownBundleWriter` schreibt eine Markdown-Datei mit Inhaltsverzeichnis und den Dateiinhalten.
     - Verwendet `ISecretMasker` (`RegexSecretMasker`) zur Maskierung vertraulicher Werte in JSON/Config-Dateien.
     - Speichert die Datei unter `Eigene Dokumente\Solutionbundler\bundles` mit dem Solution-Namen als Dateiname.

Detaillierter Ausführungspfad

- UI: `SolutionBundler.WPF.MainWindow`
  - Manuelle DI im Konstruktor: erstellt `DefaultFileScanner`, `MsBuildProjectMetadataReader`, `SimpleContentClassifier`, `Sha1HashCalculator`, `RegexSecretMasker`, `MarkdownBundleWriter` und dann `BundleOrchestrator`.
  - Beim Starten des Scans wird `BundleOrchestrator.Run` in einem Hintergrund-Task aufgerufen.

- Orchestrierung: `BundleOrchestrator` (implementiert `IBundleOrchestrator`)
  - `Run(rootPath, settings)`:
    1. `IFileScanner.Scan(rootPath, settings)` aufrufen ? `DefaultFileScanner.Scan` liefert `IReadOnlyList<FileEntry>` zurück.
    2. Für jede Datei: SHA1 mittels `IHashCalculator.Sha1` berechnen ? `Sha1HashCalculator`.
    3. Sprache klassifizieren mit `IContentClassifier.Classify` ? `SimpleContentClassifier`.
    4. `IProjectMetadataReader.EnrichBuildActions(files, rootPath)` aufrufen ? `MsBuildProjectMetadataReader`.
    5. `SolutionInfo` erstellen und `IBundleWriter.Write(info, files, settings)` aufrufen ? `MarkdownBundleWriter`.

- Ausgabe: `MarkdownBundleWriter.Write(info, files, settings)`
  - Rendert YAML-Frontmatter mit Solution-Name, Generierungszeitpunkt und .NET-Hinweis.
  - Fügt Inhaltsverzeichnis und Abschnitte für jede Datei mit fenced code blocks und klassifizierter Sprache hinzu.
  - Wenn `ScanSettings.MaskSecrets` true ist, wird der Inhalt durch `ISecretMasker.Process` geleitet.
  - Legt das Ausgabeverzeichnis an und schreibt die Datei nach `Eigene Dokumente\Solutionbundler\bundles\{SolutionName}.md`.

Konfiguration und DI

- `SolutionBundler.Core.ServiceCollectionExtensions.AddSolutionBundlerCore` registriert Standardimplementierungen für die zentralen Dienste:
  - `IFileScanner` ? `DefaultFileScanner`
  - `IProjectMetadataReader` ? `MsBuildProjectMetadataReader`
  - `IContentClassifier` ? `SimpleContentClassifier`
  - `IHashCalculator` ? `Sha1HashCalculator`
  - `ISecretMasker` ? `RegexSecretMasker`
  - `IBundleWriter` ? `MarkdownBundleWriter`
  - `IBundleOrchestrator` ? `BundleOrchestrator`

- In der WPF-Anwendung wird DI derzeit manuell in `MainWindow` ausgeführt. Um die Erweiterungsmethode zu nutzen und einen DI-Container einzusetzen:
  1. Erzeuge eine `ServiceCollection`, rufe `AddSolutionBundlerCore()` auf.
  2. Baue den `ServiceProvider` und löse `IBundleOrchestrator` auf.

Erweiterungspunkte

- Neue `IBundleWriter`-Implementierung hinzufügen (z. B. HTML) und in DI registrieren.
- `IFileScanner` ersetzen, um das Scannen auf andere Regeln umzustellen.

FAQ

Q: Wie werden Testprojekte ausgeschlossen?
A: Der Scanner identifiziert Testprojekte entweder über Pfad-Namensmuster ("test", "tests", ".test") oder durch Analyse des `.csproj` auf `IsTestProject`-Elemente oder typische Test-PackageReferences (`xunit`, `nunit`, `mstest`, `Microsoft.NET.Test.Sdk`).

Q: Wo wird die generierte Datei gespeichert?
A: `%USERPROFILE%\\Documents\\Solutionbundler\\bundles\\{SolutionName}.md`.

---

Weitere Details und Entwicklerhinweise stehen in `Developer.md`.See `Developer.md` for more details about code structure and potential improvements.