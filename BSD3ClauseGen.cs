namespace BSD3ClauseGen;

/// <summary>
/// A command-line tool for generating BSD 3-Clause License text.
/// </summary>
/// <remarks>
/// <para>Generates a standard BSD 3-Clause license based on user-provided year and author name, 
/// saving the output to a LICENSE file in the current directory.</para>
/// <para>Usage: <c>dotnet run BSD3ClauseGen.cs</c></para>
/// </remarks>
file static class Program
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

    public static string GetUserInput() => (Console.ReadLine() ?? "").Trim();

    internal static void Main()
    {
        Console.Write("Please input the year (4 digits): ");
        string yearInput = GetUserInput();
        int year;
        while (!int.TryParse(yearInput, out year) || yearInput.Length != 4)
        {
            Console.Write("Invalid year. Please retry the input (4 digits): ");
            yearInput = GetUserInput();
        }
        Console.Write("Please input the author name: ");
        string author = GetUserInput();
        while (string.IsNullOrEmpty(author))
        {
            Console.Write("Invalid author name. Please retry the input: ");
            author = GetUserInput();
        }
        string license = string.Format(LICENSE_FORMAT, year, author);
        File.WriteAllText("LICENSE", license);
        Console.WriteLine("BSD 3-Clause License file generated.");
    }
}