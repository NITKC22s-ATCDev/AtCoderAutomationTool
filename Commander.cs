namespace AtCoderAutomationTool
{
   class Commander
   {
      public static void Main(string[] args)
      {
         while (true)
         {
            Console.Write("Command :");
            var reads = Console.ReadLine()!.Split();
            var commands = Enumerable.Repeat("", 3).ToArray();
            Array.Copy(reads, commands, reads.Length);

            switch (commands[0])
            {
               case "":
                  break;
               case "build":
                  switch (commands[1])
                  {
                     case "":
                        Build.Run();
                        break;
                     case "help":
                        Help.OutHelp("build");
                        break;
                     default:
                        Error.OptNotFound(commands[1]);
                        break;
                  }
                  break;
               case "login":
                  switch (commands[1])
                  {
                     case "":
                        Error.NotEnterdOpt();
                        break;
                     case "acc":
                        switch (commands[2])
                        {
                           case "":
                              CommandRunner.Run("acc login");
                              break;
                           case "help":
                              Help.OutHelp("login/acc");
                              break;
                           default:
                              Error.OptNotFound(commands[2]);
                              break;
                        }
                        break;
                     case "oj":
                        switch(commands[2])
                        {
                           case "":
                              CommandRunner.Run("oj login https://atcoder.jp");
                              break;
                           case "help":
                              Help.OutHelp("login/oj");
                              break;
                           default:
                              Error.OptNotFound(commands[2]);
                              break;
                        }
                        break;
                     case "help":
                        Help.OutHelp("login");
                        break;
                     default:
                        Error.OptNotFound(commands[1]);
                        break;
                  }
                  break;
               case "logout":
                  switch (commands[1])
                  {
                     case "":
                        Error.NotEnterdOpt();
                        break;
                     case "acc":
                        switch (commands[2])
                        {
                           case "":
                              CommandRunner.Run("acc logout");
                              break;
                           case "help":
                              Help.OutHelp("logout/acc");
                              break;
                           default:
                              Error.OptNotFound(commands[2]);
                              break;
                        }
                        break;
                     case "oj":
                        switch (commands[2])
                        {
                           case "":
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
                              break;
                           case "help":
                              Help.OutHelp("logout/oj");
                              break;
                           default:
                              Error.OptNotFound(commands[2]);
                              break;
                        }
                        break;
                     case "help":
                        Help.OutHelp("logout");
                        break;
                     default:
                        Error.OptNotFound(commands[1]);
                        break;
                  }
                  break;
               case "quit":
                  return;
               default:
                  Error.CmdNotFound(commands[0]);
                  break;
            }

            Console.WriteLine();
         }
      }
   }
}
