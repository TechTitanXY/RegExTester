using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace RegExTester.Helpers
{
    public static class RegexHighlighter
    {
        public static Paragraph HighlightMatches(string input, string pattern)
        {
            var paragraph = new Paragraph();
            try
            {
                var matches = Regex.Matches(input, pattern ?? "");
                int lastIndex = 0;

                foreach (Match match in matches)
                {
                    if (match.Index > lastIndex)
                        paragraph.Inlines.Add(new Run(input.Substring(lastIndex, match.Index - lastIndex)));

                    var highlight = new Run(match.Value)
                    {
                        Background = Brushes.Yellow,
                        FontWeight = FontWeights.Bold
                    };
                    paragraph.Inlines.Add(highlight);
                    lastIndex = match.Index + match.Length;
                }

                if (lastIndex < input.Length)
                    paragraph.Inlines.Add(new Run(input.Substring(lastIndex)));
            }
            catch
            {
                paragraph.Inlines.Add(new Run(input));
            }

            return paragraph;
        }
    }
}