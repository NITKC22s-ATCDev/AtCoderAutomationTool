using System.Diagnostics;
using System.Runtime.CompilerServices;

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

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Login");
            Console.ResetColor();
            Console.WriteLine("acc :");
            Login("/c acc login");
            Console.WriteLine("oj :");
            Login("/c oj login https://atcoder.jp/");

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A㏄ configuration settings");
            Console.ResetColor();
            if (ConfigSet(new string[] { "/c acc config default-task-choice", "all" }) && ConfigSet(new string[] { "/c acc config default-test-dirname-format", "test" }))
            {
                Console.WriteLine("Success");
            }
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

        private static bool ConfigSet(string[] commands)
        { 
            StreamReader sro;
            string outputSentence="";
            for (int i = 0; i < 2; i++)
            {
                using (var pro = new Process())
                {
                    var psi = new ProcessStartInfo("cmd.exe", commands[0] + (i == 0 ? " " + commands[1] : ""));
                    psi.CreateNoWindow = true;
                    psi.UseShellExecute = false;
                    psi.RedirectStandardError = true;
                    psi.RedirectStandardOutput = true;

                    pro.StartInfo = psi;
                    pro.Start();
                    pro.WaitForExit();

                    StreamReader sre = pro.StandardError;
                    sro = pro.StandardOutput;
                    string errorSentence = sre.ReadToEnd();
                    outputSentence=sro.ReadLine();

                    if (errorSentence.Length != 0)
                    {
                        Console.WriteLine("error :");
                        Console.WriteLine(errorSentence);

                        while (true)
                        {

                            Console.WriteLine("Would you like to try again? (Y/n)");
                            string retryYN = Console.ReadLine();
                            if (retryYN.Length == 0 || retryYN == "Y" || retryYN == "y")
                            {
                                if (ConfigSet(commands))
                                {
                                    i--;
                                    continue;
                                }
                                break;
                            }
                            else if (retryYN == "N" || retryYN == "n") return false;
                        }
                    }
                }                
            }

            if (commands[1] == outputSentence)
            {
                return true;
            }
            else return false;
        }
    }
}