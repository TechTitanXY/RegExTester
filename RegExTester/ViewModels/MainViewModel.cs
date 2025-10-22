using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using RegExTester.Commands;

namespace RegExTester.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string _pattern;
        private string _testText;
        private string _matchResult;
        private string _selectedPattern;

        public string Pattern
        {
            get => _pattern;
            set
            {
                _pattern = value;
                OnPropertyChanged();
                UpdateMatchResult();
            }
        }

        public string TestText
        {
            get => _testText;
            set
            {
                _testText = value;
                OnPropertyChanged();
                UpdateMatchResult();
            }
        }

        public string MatchResult
        {
            get => _matchResult;
            set
            {
                _matchResult = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> SamplePatterns { get; } = new()
        {
            @"\b\w+@\w+\.\w+\b",           // Email
            @"\b\d{3}-\d{2}-\d{4}\b",      // SSN
            @"\b\d{10}\b",                 // Phone (basic)
            @"\b(?:\d{1,3}\.){3}\d{1,3}\b" // IP Address
        };

        public string SelectedPattern
        {
            get => _selectedPattern;
            set
            {
                _selectedPattern = value;
                Pattern = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<string> MatchHistory { get; } = new();

        public ICommand ExportCommand => new RelayCommand(ExportMatches);

        private void ExportMatches()
        {
            try
            {
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "regex_matches.txt");
                File.WriteAllText(path, MatchResult);
                MessageBox.Show($"Exported to {path}", "Export Successful");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Error");
            }
        }

        private void UpdateMatchResult()
        {
            try
            {
                var matches = Regex.Matches(TestText ?? "", Pattern ?? "");
                MatchResult = $"Matches found: {matches.Count}";
                MatchHistory.Insert(0, $"{DateTime.Now:T} → {Pattern} → {matches.Count} match(es)");
            }
            catch (Exception ex)
            {
                MatchResult = $"Error: {ex.Message}";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
