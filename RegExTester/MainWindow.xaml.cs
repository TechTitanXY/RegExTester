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
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }

        private void TestRichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (DataContext is not MainViewModel viewModel) return;

            string text = new TextRange(TestRichTextBox.Document.ContentStart, TestRichTextBox.Document.ContentEnd).Text;
            viewModel.TestText = text;

            TestRichTextBox.Document.Blocks.Clear();
            TestRichTextBox.Document.Blocks.Add(RegexHighlighter.HighlightMatches(text, viewModel.Pattern));
        }
    }
}