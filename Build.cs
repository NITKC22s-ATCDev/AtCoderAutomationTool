using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.IO;
using System.Text;
using Microsoft.VisualBasic;
using System;
using System.Text.Json;

namespace AtCoderAutomationTool
{
    internal class Build
    {
        static string roamingPath=Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        internal static void Run()
        {
            CustomOutput.ColorWriteLine("Install", ConsoleColor.Green);
            if(! Install())return;

            CustomOutput.ColorWriteLine("Check linkage between oj and acc",ConsoleColor.Green);
            

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A㏄ configuration settings");
            Console.ResetColor();
            if (ConfigSet(new string[] { "acc config default-task-choice", "all" }) && ConfigSet(new string[] { "acc config default-test-dirname-format", "test" }))
            {
                Console.WriteLine("Success");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Template configuration settings");
            Console.ResetColor();
            if (ConfigSet(new string[] { "acc config default-template", "cs" }))
            {
                Console.WriteLine("Success");
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Create templates");
            Console.ResetColor();
            Templates();

        }





        private static bool Install()
        {
            Install npmInstall = new Install("npm", "npm -v", false);
            if (!npmInstall.InstalledCheck()) return false;
            Console.WriteLine();
            Install pip3Install = new Install("pip3", "pip3 --version", false);
            if (!pip3Install.InstalledCheck()) return false;
            Console.WriteLine();
            Install accInstall = new Install("acc", "acc -v", true, "npm install -g atcoder-cli");
            if (!accInstall.InstalledCheck()) return false;
            Console.WriteLine();
            Install ojInstall = new Install("oj", "oj --version", true, "pip3 install online-judge-tools");
            if (!ojInstall.InstalledCheck()) return false;
            Console.WriteLine();
            return true;
        }

        private static bool ConfigSet(string[] commands)
        {
            StreamReader sro;
            string outputSentence = "";
            string errorSentence = "";
            for (int i = 0; i < 2; i++)
            {

                string[] outputs = CommandRunner.RunReadOut(commands[0] + (i == 0 ? " " + commands[1] : ""));
                outputSentence = outputs[0];
                errorSentence = outputs[1];

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
            

            if (commands[1] == outputSentence)
            {
                return true;
            }
            else return false;
        }

        internal static void Templates()
        {
            string[] templateFilePaths=Directory.GetFiles(roamingPath+@"\AtCoderAutomationTool\templates");
            string templateFiles="";

            for(int i=0;i<templateFilePaths.Length;i++)
            {
                templateFiles+="\""+Path.GetFileName(templateFilePaths[i])+"\"";
                if (i == templateFilePaths.Length - 1) break;
                templateFiles += ",";
            }

            foreach(string templateFilePath in templateFilePaths)
            {
                File.Copy(templateFilePath, roamingPath + @"\atcoder-cli-nodejs\config\cs\" + Path.GetFileName(templateFilePath),true);
            }

            Console.WriteLine("Please select the file you wish to submit \n(Select with the up key and down key. Decide with the Enter key.)\n");

            int selectedFile =0;
            int top;
            Console.CursorVisible = false;
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor forground = Console.ForegroundColor;
            while(true)
            {
                
                for(int i=0;i<templateFilePaths.Length;i++)
                {
                    Console.WriteLine(Path.GetFileName(templateFilePaths[i]));
                }
                top =Console.CursorTop;

                Console.SetCursorPosition(0, top - templateFilePaths.Length+selectedFile);
                Console.BackgroundColor = forground;
                Console.ForegroundColor = background;

                
                Console.WriteLine(Path.GetFileName(templateFilePaths[selectedFile]));
                Console.ResetColor();

                ConsoleKeyInfo pushedKey = Console.ReadKey(true);
                if(pushedKey.Key==ConsoleKey.UpArrow&&selectedFile>0)
                {
                    selectedFile--;
                }
                else if(pushedKey.Key==ConsoleKey.DownArrow&&selectedFile<templateFilePaths.Length-1)
                {
                    selectedFile++;
                }
                else if(pushedKey.Key==ConsoleKey.Enter)
                {
                    Console.CursorTop = top;
                    break;
                }
                Console.SetCursorPosition(0, top - templateFilePaths.Length);

            }
            Console.CursorVisible = true;
            Console.ResetColor();
            top = 0;

            Directory.CreateDirectory(roamingPath + @"\atcoder-cli-nodejs\config\cs");
            using (StreamWriter sw = new StreamWriter(roamingPath + @"\atcoder-cli-nodejs\config\cs\template.json"))
            {
                string writeContents = "{\"task\":{\"program\":[" + templateFiles + "],\"submit\":\"" + Path.GetFileName(templateFilePaths[selectedFile])+"\"}}";
                sw.Write(writeContents);
            }
        }
    }
}