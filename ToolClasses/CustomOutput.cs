using System;

namespace AtCoderAutomationTool
{
    internal class CustomOutput
    {
        internal static void ColorWriteLine(string s,ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.WriteLine(s);
            Console.ResetColor();
        }

        internal static void ColorWrite(string s,ConsoleColor c)
        {
            Console.ForegroundColor = c;
            Console.Write(s);
            Console.ResetColor();
        }
    }
}
