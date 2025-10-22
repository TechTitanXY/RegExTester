using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using RegExTester.ViewModels;
using RegExTester.Helpers;

namespace RegExTester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Reentrancy guard field added here
        private bool _isUpdatingRichText;

        public MainWindow()
        {
            InitializeComponent();
            Title = "Regex Tester by Phillip Galey";
            DataContext = new MainViewModel();
        }

        private void TestRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isUpdatingRichText) return;
            if (DataContext is not MainViewModel viewModel) return;

            // Update ViewModel's TestText
            string text = new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd).Text;
            viewModel.TestText = text;

            /// Update highlighted text
            try
            {
                _isUpdatingRichText = true;
                TestRichTextBox.Document.Blocks.Clear();
                TestRichTextBox.Document.Blocks.Add(RegexHighlighter.HighlightMatches(text, viewModel.Pattern));
            }
            finally
            {
                _isUpdatingRichText = false;
            }
        }
    }
}