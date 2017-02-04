using System;

namespace AcademyRPG
{
    class Program
    {
        static Engine GetEngineInstance()
        {
            return new ExtendEngine();
        }

        static void Main(string[] args)
        {
            Engine engine = GetEngineInstance();

            string command = Console.ReadLine();
            while (command != "end")
            {
                engine.ExecuteCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}
