using System;
using System.Diagnostics;
using System.Text;

namespace AtCoderAutomationTool
{
    internal class CommandRunner
    {
        //Configuration of running processes.
        private static ProcessStartInfo SetStartInfo(bool read,string command)

        {
            string[] returns = new string[2];

            var psi = new ProcessStartInfo("cmd.exe","/c "+command);
            psi.CreateNoWindow = read;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = read;
            psi.RedirectStandardError = read;

            return psi;
        }

        //Display all outputs
        public static void Run(string command)
        {
            var pro=new Process();
            pro.StartInfo = SetStartInfo(false,command);
            pro.Start();
            pro.WaitForExit();
        }

        //Get output in string array.[0]:Standard Output [1]:Standard Error Output
        public static string[] RunReadOut(string command)
        {
            string[] returns=new string[2];
            using (var pro =new Process())
            {
                pro.StartInfo= SetStartInfo(true,command);
                pro.Start();
                pro.WaitForExit();
                var sr = pro.StandardOutput;
                returns[0] = sr.ReadToEnd();
                sr = pro.StandardError;
                returns[1] = sr.ReadToEnd();
            }

            return returns;
        }
    }
}