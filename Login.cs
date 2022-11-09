using System.Diagnostics;

namespace AtCoderAutomationTool
{
   internal class Login
   {
      internal static void Control()
      {
         Console.Write("User Name :");
         string userName = Console.ReadLine();

         Console.Write("Password :");
         Console.ForegroundColor = ConsoleColor.DarkGray;
         Console.Write("(Hidden)");
         Console.ResetColor();
         string password = null;
         while (true)
         {
            ConsoleKeyInfo inputedkey = Console.ReadKey(true);
            if (inputedkey.Key == ConsoleKey.Enter) break;
            password += inputedkey.KeyChar;
         }
         Console.WriteLine();
         Run("/c acc login", userName, password);
         Console.WriteLine();
      }

      private static bool Run(string command, string userName, string password)
      {
         using (Process pro = new Process())
         {
            var psi = new ProcessStartInfo("cmd.exe", command);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            psi.RedirectStandardError = false;
            psi.RedirectStandardOutput = false;
            psi.RedirectStandardInput = true;

            pro.StartInfo = psi;
            pro.Start();

            StreamWriter sw = pro.StandardInput;

            sw.WriteLine(userName);
            pro.WaitForExit();
            sw.WriteLine(password);
            pro.WaitForExit();


            Console.WriteLine();
            return true;
         }
      }

   }
}
