using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using SolutionBundler.Core.Abstractions;
using SolutionBundler.Core.Implementations;
using SolutionBundler.Core.Models;

namespace SolutionBundler.WPF;

public partial class MainWindow : Window
{
    private readonly IBundleOrchestrator _orchestrator;
    private string? _lastOutput;

    public MainWindow()
    {
        InitializeComponent();

        // Einfache "manuelle DI"
        var scanner = new DefaultFileScanner();
        var meta = new MsBuildProjectMetadataReader();
        var classifier = new SimpleContentClassifier();
        var hasher = new Sha1HashCalculator();
        var masker = new RegexSecretMasker();
        var writer = new MarkdownBundleWriter(masker);
        _orchestrator = new BundleOrchestrator(scanner, meta, classifier, hasher, writer);
    }

    private void Browse_Click(object sender, RoutedEventArgs e)
    {
        using var dlg = new FolderBrowserDialog();
        dlg.Description = "Ordner wählen, der die .sln-Datei enthält";
        if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            RootBox.Text = dlg.SelectedPath;

            // Set default output filename to solution name if a .sln is present
            try
            {
                var sln = Directory.EnumerateFiles(dlg.SelectedPath, "*.sln", SearchOption.TopDirectoryOnly)
                                   .Select(Path.GetFileName)
                                   .FirstOrDefault();
                if (!string.IsNullOrWhiteSpace(sln))
                {
                    OutputName.Text = Path.GetFileNameWithoutExtension(sln) + ".md";
                }
                else
                {
                    OutputName.Text = "Bundle.md";
                }
            }
            catch
            {
                OutputName.Text = "Bundle.md";
            }
        }
    }

    private async void Run_Click(object sender, RoutedEventArgs e)
    {
        var root = RootBox.Text;
        if (string.IsNullOrWhiteSpace(root) || !Directory.Exists(root))
        {
            System.Windows.MessageBox.Show("Bitte ein gültiges Root-Verzeichnis wählen.");
            return;
        }

        var slnExists = Directory.EnumerateFiles(root, "*.sln", SearchOption.TopDirectoryOnly).Any();
        if (!slnExists)
        {
            System.Windows.MessageBox.Show("Im gewählten Ordner wurde keine .sln gefunden.");
            return;
        }

        try
        {
            IsEnabled = false;
            StatusText.Text = "Scanne und erstelle Bundle…";
            Prog.Value = 50;

            // Determine output filename: prefer explicit text; if empty or default use solution name
            var outputText = OutputName.Text;
            if (string.IsNullOrWhiteSpace(outputText) || string.Equals(outputText, "Bundle.md", StringComparison.OrdinalIgnoreCase))
            {
                var sln = Directory.EnumerateFiles(root, "*.sln", SearchOption.TopDirectoryOnly)
                                   .Select(Path.GetFileName)
                                   .FirstOrDefault();
                var baseName = !string.IsNullOrWhiteSpace(sln) ? Path.GetFileNameWithoutExtension(sln) : Path.GetFileName(root);
                outputText = baseName + ".md";
                OutputName.Text = outputText; // update UI so user sees computed name
            }

            var settings = new ScanSettings
            {
                MaskSecrets = ChkMask.IsChecked == true,
                OutputFileName = outputText
            };

            _lastOutput = await Task.Run(() => _orchestrator.Run(root, settings));

            Prog.Value = 100;
            StatusText.Text = $"Fertig: {_lastOutput}";
        }
        catch (Exception ex)
        {
            System.Windows.MessageBox.Show("Fehler: " + ex.Message);
            StatusText.Text = "Fehler.";
        }
        finally
        {
            IsEnabled = true;
        }
    }

    private void Open_Click(object sender, RoutedEventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(_lastOutput) && File.Exists(_lastOutput))
        {
            Process.Start(new ProcessStartInfo { FileName = _lastOutput, UseShellExecute = true });
        }
        else
        {
            System.Windows.MessageBox.Show("Es liegt noch kein Ergebnis vor.");
        }
    }
}