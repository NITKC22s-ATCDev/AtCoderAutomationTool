using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace AtCoderAutomationTool
{
   public class Help
   {
      public static void OutHelp(string command)
      {
         var assembly = Assembly.GetExecutingAssembly();
         var stream = assembly.GetManifestResourceStream("AtCoderAutomationTool.Help.Helps.json");
         Option? jsonHelps =new Option();         
         jsonHelps = JsonSerializer.Deserialize<Option>(stream, new JsonSerializerOptions());

         var nowcommands = jsonHelps;
         string[] commands = command.Split('/');
         for(int i=0;i<commands.Length; i++)
         {
            nowcommands=nowcommands.options.Find(n=>n.command== commands[i]);
         }

         Console.Write(
         $"Description\t: {nowcommands.description}\n\n" +
         $"Usage\t\t: {nowcommands.usage}\n\n"+
         $"Options:\n"
         );

         foreach(var o in nowcommands.options)
         {
            Console.WriteLine($"{o.command}\t{o.description}");
         }

      }
   }
}
