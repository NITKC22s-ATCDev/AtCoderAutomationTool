namespace AtCoderAutomationTool
{
    class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Command :");
                string[] commands = Console.ReadLine().Split();
                if (commands[0] == "build")
                {
                    Build.Run();
                }
                else if (commands[0] == "quit") break;
                else if (commands[0] == "") Console.Error.WriteLine("Please enter some command.");
                else Console.Error.WriteLine("Not found the command :" + commands[0]);
                Console.WriteLine();
            }
        }
    }
}