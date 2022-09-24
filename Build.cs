using System.Diagnostics;

namespace AtCoderAutomationTool
{
    internal class Build
    {
        internal static void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Install");
            Console.ResetColor();
            Install();

            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Login");
            Console.ResetColor();
            Console.WriteLine("acc :");
            Login("/c acc login");
            Console.WriteLine("oj :");
            Login("/c oj login https://atcoder.jp/");
        }

        private static void Install()
        {
            Install npmInstall = new Install("npm", "/c npm -v", false);
            if (!(npmInstall.InstalledCheck())) return;
            Console.WriteLine();
            Install pip3Install = new Install("pip3", "/c pip3 --version", false);
            if (!(pip3Install.InstalledCheck())) return;
            Console.WriteLine();
            Install accInstall = new Install("acc", "/c acc -v", true, "/c npm install -g atcoder-cli");
            if (!(accInstall.InstalledCheck())) return;
            Console.WriteLine();
            Install ojInstall = new Install("oj", "/c oj --version", true, "/c pip3 install online-judge-tools");
            if (!(ojInstall.InstalledCheck())) return;
            Console.WriteLine();
        }

        private static void Login(string command)
        {
            var psi = new ProcessStartInfo("cmd.exe", command);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            Process pro = new Process();
            pro.StartInfo = psi;
            pro.Start();
            pro.WaitForExit();
            Console.WriteLine();
        }
    }
}
