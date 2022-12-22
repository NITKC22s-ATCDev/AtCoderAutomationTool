namespace AtCoderAutomationTool
{
   class Program
   {
      public static void Main(string[] args)
      {
         while (true)
         {
            Console.Write("Command :");
            string[] commands = Console.ReadLine()!.Split();
            if (commands[0] == "build")
            {
               Build.Run();
            }
            else if (commands[0] == "login")
            {
               if (commands[1] == "acc") Login.Acc();
               else if (commands[1] == "oj") Login.Oj();
               else if (commands[1]=="") Console.Error.WriteLine("Please enter some option");
               else Console.Error.WriteLine("The option not found :" + commands[1]);
            }
            else if (commands[0] == "quit") break;
            else if (commands[0] == "") Console.Error.WriteLine("Please enter some command.");
            else Console.Error.WriteLine("The command not found :" + commands[0]);
            Console.WriteLine();
         }
      }
   }
}