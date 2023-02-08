namespace AtCoderAutomationTool
{
   class Commander
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
               if (commands.Length < 2) Console.Error.WriteLine("Please enter some option.");
               else if (commands[1] == "acc") CommandRunner.Run("acc login");
               else if (commands[1] == "oj") CommandRunner.Run("oj login https://atcoder.jp");
               else Console.Error.WriteLine("The option not found :" + commands[1]);
            }
            else if (commands[0] == "logout")
            {
               if (commands[1] == "acc") CommandRunner.Run("acc log");
               else if (commands[1] == "oj")
               {
                  while (true)
                  {
                     Console.Write("When executed, all accounts logged in to oj will be logged out.Are you sure you want to logout? [Y/n] :");
                     string logoutYN = Console.ReadLine()!;
                     if (logoutYN.Length == 0 || logoutYN == "y" || logoutYN == "Y")
                     {
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\online-judge-tools\\online-judge-tools\\cookie.jar");
                        break;
                     }
                     else if (logoutYN == "n" || logoutYN == "N") break;
                  }
               }
               else if (commands[1] == "") Console.Error.WriteLine("Please enter some options.");
               else Console.Error.WriteLine("The option not found :" + commands[1]);
            }
            else if (commands[0] == "quit") break;
            else if (commands[0] == "") Console.Error.WriteLine("Please enter some commands.");
            else Console.Error.WriteLine("The command not found :" + commands[0]);
            Console.WriteLine();
         }
      }
   }
}
