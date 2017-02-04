namespace VehicleParkSystem
{
    using System;

    using VehicleParkSystem.Interfaces;

    public class Engine : IEngine
    {
        private readonly CommandExecutor CommandExecutor;

        public Engine()
        {
            CommandExecutor = new CommandExecutor();
        }

        public void Run()
        {
            string currentLine = string.Empty;
            while (!string.IsNullOrEmpty(currentLine = Console.ReadLine().Trim()))
            {
                try
                {
                    var command = new Command(currentLine);
                    string commandResult = CommandExecutor.Execute(command);
                    Console.WriteLine(commandResult);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}