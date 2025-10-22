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

| Layer         | Technology                     |
|--------------|---------------------------------|
| UI           | WPF (.NET 9.0)                  |
| Logic        | C# 12, MVVM                     |
| Highlighting | RichTextBox + RegexHighlighter |
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
---