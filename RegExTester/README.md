# RegExTester (.NET 9.0 WPF)

A lightweight desktop utility for testing regular expressions in real-time, built with WPF and MVVM. 
Designed to showcase clean architecture, responsive UI, and modular design.

## ✨ Features

- 🔍 Live RegEx matching with instant feedback
- 🎨 Match highlighting in RichTextBox
- 📚 Sample pattern library (email, SSN, IP, etc.)
- 🕰️ Match history panel with timestamped entries
- 📤 Export match results to `.txt` file
- 🧠 MVVM architecture with modular helpers and commands

## 🧪 Tech Stack

| Layer        | Technology                      |
|--------------|---------------------------------|
| UI           | WPF (.NET 9.0)                  |
| Logic        | C# 12, MVVM                     |
| Highlighting | RichTextBox + RegexHighlighter  |
| Commands     | RelayCommand (ICommand)         |
| Export       | File I/O to Desktop             |

## 🚀 How to Run

1. Clone the repo
2. Open in Visual Studio 2022+
3. Build and run (`Ctrl+F5`)

## 📌 Folder Structure

 RegExTester/ 
 ├── MainWindow.xaml / .cs 
 ├── ViewModels/ 
 │ └── MainViewModel.cs 
 ├── Helpers/ 
 │ └── RegexHighlighter.cs 
 ├── Commands/ 
 │ └── RelayCommand.cs 
 ├── Models/ 
 │ └── (reserved for future expansion) 
 ├── README.md

 
## 🧠 Why This Project?

Built to demonstrate modern WPF development with MVVM, modular architecture, and responsive UI. Ideal for desktop tooling roles, internal utilities, or showcasing C# fluency in technical interviews.

## 🔮 Future Enhancements

- Export to JSON or CSV
- Syntax-aware highlighting (e.g., groups, quantifiers)
- RegEx cheat sheet panel
- Dark mode toggle

ISSUE RESOLVED:

Issue: Pasting text into the RichTextBox triggered a StackOverflowException.

Cause: The TextChanged event handler (TestRichTextBox_TextChanged) was mutating TestRichTextBox.Document during its own execution. This re-triggered the same event recursively, leading to a stack overflow.

Fix: Introduced a reentrancy guard (_isUpdatingRichText) to prevent recursive entry during document updates. This ensures the handler only runs once per change cycle.

Result: RichTextBox now safely displays pasted content, highlights matches in real time, and avoids infinite recursion.


## 🔮 TEST/DEMO Patterns

1. EMAILS

Pattern:
\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b

Test string:
Contact: alice@example.com, bob.smith@mail.co.uk; invalid@.com, user+tag@domain.org

Expected highlights:
alice@example.com, bob.smith@mail.co.uk, user+tag@domain.org (3 matches)

2. US PHONE NUMBERS

Pattern:
\b\d{3}-\d{3}-\d{4}\b

Test string:
Call 555-123-4567 or 212-555-0199. Extension 5551234 should not match.

Expected highlights:
555-123-4567, 212-555-0199 (2 matches)

3. IPV4 ADDRESSES

Pattern:
\b(?:\d{1,3}\.){3}\d{1,3}\b

Test string:
Valid? 192.168.0.1, 10.0.0.254, 999.999.999.999

Expected highlights:
All three will be matched; note: regex doesn't validate octet ≤255.

4. DATES (MM/DD/YYYY)

Pattern:
\b(0[1-9]|1[0-2])/(0[1-9]|[12][0-9]|3[01])/\d{4}\b

Test string:
Important dates: 01/15/2023, 12/31/2022, and 02/29/2020 are valid; however, 02/30/2021 should not match.

Expected highlights:
01/15/2023, 12/31/2022, 02/29/2020 (3 matches)


5. SOCIAL SECURITY NUMBERS

Pattern:
\b\d{3}-\d{2}-\d{4}\b
Test string:
Valid:	 SSNs: 123-45-6789, 987-65-4320
Invalid: 12-345-6789, 123456789
Expected highlights:
123-45-6789, 987-65-4320 (2 matches)

6. Find words before a colon

Pattern:
\b\w+(?=:)\b	or		\b\w+(?=:\s*)

Test string:
Important info: This is a test: Validate before this: check this too:

Expected highlights:
This, Validate, check (3 matches)

7.  Multi-line comments (C-style)

Pattern:
/\*[\s\S]*?\*/
Test string:
\/\* This is a multi-line comment \*/

Expected highlights:
\/\* This is a multi-line comment \*/ (1 match)

8.  HTML Tags

Pattern:
<([a-zA-Z][a-zA-Z0-9]*)\b[^>]*>(.*?)<\/\1>
Test string:
<div class="container">Content here</div> <span>More content</span>
Expected highlights:
<div class="container">Content here</div>, <span>More content</span> (2 matches)

