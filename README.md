# BSD 3-Clause License Generator (Python & C#)

## Description
This project provides two implementations of a BSD 3-Clause License Generator:
- **Python version**: A graphical user interface (GUI) application using Tkinter
- **C# version**: A GUI application using .NET SDK 10's single-file execution and Windows Forms

Both versions generate a standard BSD 3-Clause License text based on the provided year and author name.

## Features

### GUI Version (Python & C#)
- User-friendly interface with input fields for year and author name
- Real-time input validation
- Generate license with a single click
- Copy generated license to clipboard
- Responsive design
- Keyboard shortcut support (Ctrl+Enter to generate)

## Prerequisites

### For Python Version
- Python 3.10 or higher
- Tkinter (usually included with Python installations)

### For C# Version
- [.NET SDK 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)

## Installation & Usage
First, clone the repository and navigate to the project directory:
```bash
git clone https://github.com/Pac-Dessert1436/bsd-3-clause-generator.git
cd bsd-3-clause-generator
```

### Python GUI Version
1. Run the script:
   ```bash
   python bsd_3_clause_gen.py
   ```
2. Enter the 4-digit year and author name in the input fields
3. Click "Generate License" or press Ctrl+Enter
4. The generated license will appear in the text area
5. Click "Copy to Clipboard" to copy the license text

### C# GUI Version
1. Run the program:
   ```bash
   dotnet run BSD3ClauseGen.cs
   ```
2. Enter the 4-digit year and author name in the input fields
3. Click "Generate License" or press Ctrl+Enter
4. The generated license will appear in the text area
5. Click "Copy to Clipboard" to copy the license text

## Project Structure
- `bsd_3_clause_gen.py` - Python GUI implementation
- `BSD3ClauseGen.cs` - C# GUI implementation
- `LICENSE` - BSD 3-Clause License file
- `README.md` - This documentation

## License
This project is licensed under the BSD 3-Clause License. See the [LICENSE](LICENSE) file for details.