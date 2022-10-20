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

            string errorSentence = CommandRunner.RunReadOut(this.arguments)[1];

            if (errorSentence.Length > 0)
            {
                Console.Error.WriteLine(fileName + " :error >>\n" + errorSentence);

                if (allowInstall)
                {
                    while (true)
                    {
                        Console.Write("Do you want to install or reinstall " + this.fileName + "? [Y/n] :");
                        string installYN = Console.ReadLine()!;
                        if (installYN.Length ==0 || installYN == "y" || installYN == "Y")
                        {
                            CommandRunner.Run(installCommand);
                            CustomOutput.ColorWriteLine("Please restart command window.", ConsoleColor.Red);
                            Console.Write("Please enter eny key.");
                            Console.ReadKey();
                            Environment.Exit(0);
                            return false;
                        }
                        return false;
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
}
