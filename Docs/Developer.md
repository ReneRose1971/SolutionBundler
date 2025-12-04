# Entwicklerhinweise

Dieses Entwicklertutorial erklärt Architekturentscheidungen, Einstiegspunkte und wie SolutionBundler erweitert werden kann.

Projekteinstiegspunkte

- WPF UI: `SolutionBundler.WPF` ? `MainWindow.xaml.cs` ist der Nutzer-Einstiegspunkt.
- Kern-Orchestrierung: `SolutionBundler.Core.Implementations.BundleOrchestrator.Run`.

Dependency Injection

- `SolutionBundler.Core.ServiceCollectionExtensions` registriert Standardimplementierungen.
- Die WPF-App verwendet derzeit manuelle DI in `MainWindow`. Um DI einzusetzen:
  - Füge `Microsoft.Extensions.DependencyInjection` zum WPF-Projekt hinzu.
  - Erstelle eine `ServiceCollection` und rufe `AddSolutionBundlerCore()` auf.
  - Baue einen `ServiceProvider` und löse `IBundleOrchestrator` auf.

Wichtige Klassen

- `DefaultFileScanner` - durchsucht Dateien anhand von `ScanSettings` und erkennt Testprojekte.
- `MsBuildProjectMetadataReader` - liest `.csproj` ItemGroup-Einträge und ordnet BuildAction-Werte zu.
- `Sha1HashCalculator` - berechnet SHA1.
- `SimpleContentClassifier` - mappt Dateiendungen zu Code-Fence-Sprachen.
- `RegexSecretMasker` - maskiert Secrets in JSON/Config-Dateien.
- `MarkdownBundleWriter` - erstellt eine Markdown-Ausgabe und schreibt sie auf die Festplatte.

Erweiterungen

- Neue `IBundleWriter`-Implementierung: zum Beispiel HTML-Export.
- Eigenes `IFileScanner` implementieren, um alternative Scanning-Strategien zu nutzen.

Testing

- Unit-Tests befinden sich in `SolutionBundler.Tests`. Füge Tests für neue Komponenten und DI-Registrierungen hinzu.

Anmerkungen

- Es ist empfehlenswert, die manuelle DI in `MainWindow` durch einen Startup/Composition-Ansatz zu ersetzen, um Testbarkeit und Lesbarkeit zu verbessern.
- Für sehr große Lösungen sollten asynchrone IO-Operationen im Scanner/Writer in Betracht gezogen werden.
