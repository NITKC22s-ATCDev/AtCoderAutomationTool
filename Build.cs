using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderAutomationTool
{
    internal class Build
    {
        internal static void InstalledCheck(string fileName, string arguments,bool allowInstall)
        {
            using (var pro = new Process())
            {
                var psi = new ProcessStartInfo("cmd.exe", arguments);
                psi.CreateNoWindow = true;
                psi.UseShellExecute = false;
                psi.RedirectStandardError = true;
                psi.RedirectStandardInput = true;
                psi.RedirectStandardInput = true;
                pro.StartInfo = psi;
                pro.Start();
                pro.WaitForExit();
                StreamReader sr = pro.StandardError;
                string errorSentence=sr.ReadToEnd();
                if (errorSentence.Length>0)
                {
                    Console.WriteLine("error :\n"+errorSentence);

                }
                else
                {
                    Console.WriteLine(fileName+" :OK");
                }
            }
        }
    }
}
