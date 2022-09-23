using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderAutomationTool
{
    internal class Build
    {
        internal static void Run()
        {
            Install();
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
        }
    }
}
