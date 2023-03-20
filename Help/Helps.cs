using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtCoderAutomationTool
{

   public class Option
   {
      public string command { get; set; }
      public string description { get; set; }
      public string usage { get; set; }
      public List<Option> options { get; set; }

      public Option() 
      {
         command = "";
         description = "";
         usage = "";
         options = new List<Option>();
      }
   }
}
