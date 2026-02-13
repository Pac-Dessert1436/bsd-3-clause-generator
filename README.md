# BSD 3-Clause License Generator (Python & C#)

## Description
This project provides two implementations of a BSD 3-Clause License Generator:
- **Python version**: A graphical user interface (GUI) application using Tkinter
- **C# version**: A command-line application using .NET SDK 10's single-file execution

Both versions generate a standard BSD 3-Clause License text based on the provided year and author name.

## Features

### Python GUI Version
- User-friendly interface with input fields for year and author name
- Real-time input validation
- Generate license with a single click
- Copy generated license to clipboard
- Responsive design
- Keyboard shortcut support (Ctrl+Enter to generate)

### C# Command-Line Version
- Simple command-line interface with single-file execution
- Input validation for year format
- Generates LICENSE file in current directory
- Clear error messages for invalid inputs

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

### C# Command-Line Version
1. Run the program:
   ```bash
   dotnet run BSD3ClauseGen.cs
   ```
2. Follow the prompts to enter the year and author name
3. A LICENSE file will be generated in the current directory

## Project Structure
- `bsd_3_clause_gen.py` - Python GUI implementation
- `BSD3ClauseGen.cs` - C# command-line implementation
- `LICENSE` - BSD 3-Clause License file
- `README.md` - This documentation

## License
This project is licensed under the BSD 3-Clause License. See the [LICENSE](LICENSE) file for details.