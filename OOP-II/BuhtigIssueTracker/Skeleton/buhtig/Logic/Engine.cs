namespace BuhtigIssueTracker.Logic
{
    using System;
    using Interfaces;
    using Models;

    public class Engine : IEngine
    {
        public Engine(CommandExecutor commandExecutor)
        {
            this.CommandExecutor = commandExecutor;
        }

        public Engine() : this(new CommandExecutor())
        {
        }

        private CommandExecutor CommandExecutor { get; set; }

        public void Run()
        {
            while (true)
            {
                string currentLine = Console.ReadLine().Trim();                
                if (!string.IsNullOrEmpty(currentLine))
                {
                    try
                    {
                        var command = new Command(currentLine);
                        string viewResult = this.CommandExecutor.DispatchAction(command);
                        Console.WriteLine(viewResult);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}