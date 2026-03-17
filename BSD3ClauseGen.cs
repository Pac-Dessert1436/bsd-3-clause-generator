#:property PublishTrimmed=false
#:property TargetFramework=net10.0-windows
#:property UseWindowsForms=true

namespace BSD3ClauseGen;

file static class Program
{
    [STAThread]
    internal static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new MainForm());
    }
}

file class MainForm : Form
{
    private const string LICENSE_FORMAT = @"BSD 3-Clause License

Copyright (c) {0}, {1}
All rights reserved.

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions are met:

1. Redistributions of source code must retain the above copyright notice, this
   list of conditions and the following disclaimer.

2. Redistributions in binary form must reproduce the above copyright notice,
   this list of conditions and the following disclaimer in the documentation
   and/or other materials provided with the distribution.

3. Neither the name of the copyright holder nor the names of its
   contributors may be used to endorse or promote products derived from
   this software without specific prior written permission.

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS ""AS IS""
AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE
DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE
FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE
OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.";

    private TextBox yearTextBox = null!;
    private TextBox authorTextBox = null!;
    private Button generateButton = null!;
    private Button copyButton = null!;
    private RichTextBox licenseTextBox = null!;
    private Label messageLabel = null!;
    private System.Windows.Forms.Timer messageTimer = null!;

    public MainForm()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        SuspendLayout();

        Text = "BSD 3-Clause License Generator";
        Size = new Size(800, 600);
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(600, 400);

        var inputPanel = new Panel
        {
            Dock = DockStyle.Top,
            BackColor = Color.FromArgb(245, 245, 245),
            Padding = new Padding(20),
            Height = 100
        };

        var copyrightLabel = new Label
        {
            Text = "Copyright (c)",
            AutoSize = true,
            Location = new Point(20, 25),
            Font = new Font("Arial", 12)
        };

        yearTextBox = new TextBox
        {
            Width = 100,
            Location = new Point(120, 20),
            Font = new Font("Arial", 14),
            MaxLength = 4
        };
        yearTextBox.KeyPress += YearTextBox_KeyPress;
        yearTextBox.TextChanged += ValidateInputs;

        authorTextBox = new TextBox
        {
            Width = 300,
            Location = new Point(230, 20),
            Font = new Font("Arial", 14)
        };
        authorTextBox.TextChanged += ValidateInputs;

        var buttonPanel = new Panel
        {
            Location = new Point(20, 60),
            Height = 30,
            Width = 510
        };

        generateButton = new Button
        {
            Text = "Generate License",
            BackColor = Color.FromArgb(0, 123, 255),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Arial", 12),
            Size = new Size(150, 30),
            Location = new Point(0, 0),
            Enabled = false
        };
        generateButton.Click += GenerateLicense;
        generateButton.FlatAppearance.BorderSize = 0;

        copyButton = new Button
        {
            Text = "Copy to Clipboard",
            BackColor = Color.FromArgb(0, 123, 255),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Arial", 12),
            Size = new Size(150, 30),
            Location = new Point(160, 0),
            Enabled = false
        };
        copyButton.Click += CopyToClipboard;
        copyButton.FlatAppearance.BorderSize = 0;

        buttonPanel.Controls.AddRange([generateButton, copyButton]);
        inputPanel.Controls.AddRange([copyrightLabel, yearTextBox, authorTextBox, buttonPanel]);

        var outputPanel = new Panel
        {
            Dock = DockStyle.Fill,
            Padding = new Padding(20, 0, 20, 20)
        };

        licenseTextBox = new RichTextBox
        {
            Dock = DockStyle.Fill,
            Font = new Font("Courier New", 11),
            BackColor = Color.FromArgb(248, 249, 250),
            BorderStyle = BorderStyle.FixedSingle,
            ReadOnly = true,
            Text = "Please enter the year and author above to generate the BSD 3-Clause License text."
        };

        outputPanel.Controls.Add(licenseTextBox);

        messageLabel = new Label
        {
            Dock = DockStyle.Bottom,
            Height = 30,
            Font = new Font("Arial", 12),
            Text = "",
            AutoSize = false,
            TextAlign = ContentAlignment.MiddleLeft,
            Padding = new Padding(20, 5, 0, 0)
        };

        messageTimer = new System.Windows.Forms.Timer { Interval = 3000 };
        messageTimer.Tick += MessageTimer_Tick;

        Controls.AddRange([inputPanel, outputPanel, messageLabel]);
        ResumeLayout(false);
    }

    private void YearTextBox_KeyPress(object? sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            e.Handled = true;
    }

    private void ValidateInputs(object? sender, EventArgs e)
    {
        string year = yearTextBox.Text.Trim();
        string author = authorTextBox.Text.Trim();

        bool isValidYear = year.Length == 4 && int.TryParse(year, out _);
        bool isValidAuthor = author.Length > 0;

        generateButton.Enabled = isValidYear && isValidAuthor;
    }

    private void GenerateLicense(object? sender, EventArgs e)
    {
        string year = yearTextBox.Text.Trim();
        string author = authorTextBox.Text.Trim();

        string licenseText = string.Format(LICENSE_FORMAT, year, author);
        licenseTextBox.Text = licenseText;
        copyButton.Enabled = true;

        ShowMessage("License generated successfully!", "success");
    }

    private void CopyToClipboard(object? sender, EventArgs e)
    {
        string licenseContent = licenseTextBox.Text.Trim();

        if (!string.IsNullOrEmpty(licenseContent) &&
            !licenseContent.Contains("Please enter the year and author"))
        {
            Clipboard.SetText(licenseContent);
            ShowMessage("License copied to clipboard!", "success");
        }
        else
        {
            ShowMessage("No license to copy", "error");
        }
    }

    private void ShowMessage(string text, string messageType)
    {
        messageLabel.ForeColor = 
            messageType == "success" ? Color.FromArgb(40, 167, 69) : Color.FromArgb(220, 53, 69);
        messageLabel.Text = text;
        messageTimer.Start();
    }

    private void MessageTimer_Tick(object? sender, EventArgs e)
    {
        messageLabel.ResetText();
        messageTimer.Stop();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        yearTextBox.KeyPress -= YearTextBox_KeyPress;
        yearTextBox.TextChanged -= ValidateInputs;
        authorTextBox.TextChanged -= ValidateInputs;
        generateButton.Click -= GenerateLicense;
        copyButton.Click -= CopyToClipboard;
        messageTimer.Tick -= MessageTimer_Tick;
        base.OnFormClosing(e);
    }
}