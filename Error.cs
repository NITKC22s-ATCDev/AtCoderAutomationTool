using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderAutomationTool
{
   class Error
   {
      public static void OptNotFound(string notFoundedOption)
      {
         Console.Error.WriteLine($"The option not found: {notFoundedOption}");
      }

      public static void NotEnterdOpt()
      {
         Console.Error.WriteLine("Please enter some option.");
      }

      public static void CmdNotFound(string notFoundedCmd)
      {
         Console.Error.WriteLine($"The command not found: {notFoundedCmd}");
      }

   }
}