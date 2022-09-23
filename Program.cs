using System;
using System.Diagnostics;

namespace AtCoderAutomationTool
{
    class Program
    {
        public static void Main(string[] args)
        {
            while(true)
            {
                Console.Write("Command :");
                string[] commands = Console.ReadLine().Split();
                if (commands[0]=="build")
                {
                    Build.InstalledCheck("npm", "/c npm -v",false);
                    Build.InstalledCheck("pip3", "/c pip3 -v", false);
                }
                else if (commands[0] == "quit") break;
                else Console.Error.WriteLine("Not found the command :"+commands[0]);
                Console.WriteLine();
            }
        }
    }
}