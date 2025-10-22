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

---