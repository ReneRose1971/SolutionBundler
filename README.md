# SolutionBundler
WPF-Tool zum Erstellen einer vollständigen Markdown‑Dokumentation einer .NET‑Solution – inklusive Quelltexte, Projektdateien, Hashes und Build‑Aktionen.

## Projekt‑Dokumentation

Die ausführliche Projektdokumentation befindet sich im Ordner `Docs`. Zwei zentrale Seiten (klickbar):

- [Workflow](Docs/Workflow.md) — Beschreibt den Arbeitsablauf von SolutionBundler und die Architekturkomponenten (z. B. `IFileScanner` / `DefaultFileScanner`, `IProjectMetadataReader` / `MsBuildProjectMetadataReader`, `IContentClassifier` / `SimpleContentClassifier`, `IHashCalculator` / `Sha1HashCalculator`, `ISecretMasker` / `RegexSecretMasker`, `IBundleWriter` / `MarkdownBundleWriter`). Enthält außerdem Hinweise zur derzeitigen manuellen DI in der WPF‑Anwendung und typische Erweiterungspunkte.

- [Developer](Docs/Developer.md) — Entwicklerhinweise: Einstiegspunkte im Code (`SolutionBundler.WPF/MainWindow.xaml.cs`, `SolutionBundler.Core`), Empfehlungen zur Integration von Dependency Injection, Testing‑Hinweise und Vorschläge zur Erweiterung (z. B. zusätzliche `IBundleWriter`‑Implementierungen).

Hinweis: Auf GitHub sind die obigen relativen Links klickbar und verweisen direkt auf die entsprechenden Dateien im `Docs`‑Verzeichnis.
