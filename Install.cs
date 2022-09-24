using System.Diagnostics;

namespace AtCoderAutomationTool
{
    internal class Install
    {
        public string fileName;
        public string arguments;
        private bool allowInstall;
        private string installCommand;

        internal Install(string fileName, string arguments, bool allowInstall)
        {
            this.fileName = fileName;
            this.arguments = arguments;
            this.allowInstall = allowInstall;
        }

        internal Install(string fileName, string arguments, bool allowInstall, string installCommand)
        {
            this.fileName = fileName;
            this.arguments = arguments;
            this.allowInstall = allowInstall;
            this.installCommand = installCommand;
        }


        internal bool InstalledCheck()
        {
            using (var pro = new Process())
            {
                var psi = new ProcessStartInfo("cmd.exe", this.arguments);
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardError = true;
                pro.StartInfo = psi;
                pro.Start();
                pro.WaitForExit();
                StreamReader sr = pro.StandardError;
                string errorSentence = sr.ReadToEnd();

                if (errorSentence.Length > 0)
                {
                    Console.WriteLine(fileName + " :error >>\n" + errorSentence);

                    if (allowInstall)
                    {
                        while (true)
                        {
                            Console.WriteLine("Do you want to install or reinstall " + this.fileName + "? (Y/n) :");
                            string installYN = Console.ReadLine();
                            if (installYN.Length == 0 || installYN == "y" || installYN == "Y") return this.RunInstall();
                            else return false;
                        }
                    }
                    else return false;
                }
                else
                {
                    Console.WriteLine(fileName + " :OK");
                    return true;
                }
            }
        }

        bool RunInstall()
        {
            var psi = new ProcessStartInfo("cmd.exe", installCommand);
            psi.CreateNoWindow = false;
            psi.UseShellExecute = false;
            Process pro = new Process();
            pro.StartInfo = psi;
            pro.Start();
            pro.WaitForExit();

            return InstalledCheck();
        }
    }
}
