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
        private bool _isUpdatingPreview;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void TestRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (_isUpdatingPreview) return;
            if (DataContext is not MainViewModel viewModel) return;

            // Get plain text from the editable RichTextBox
            string text = new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd).Text;
            viewModel.TestText = text;

            try
            {
                _isUpdatingPreview = true;

                // Update read-only preview document only — do not touch the editing document
                var previewDoc = PreviewRichTextBox.Document;
                previewDoc.Blocks.Clear();
                previewDoc.Blocks.Add(RegexHighlighter.HighlightMatches(text, viewModel.Pattern));
            }
            finally
            {
                _isUpdatingPreview = false;
            }
        }
    }
}