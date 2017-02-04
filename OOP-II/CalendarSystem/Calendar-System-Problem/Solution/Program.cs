using System;

namespace CalendarSystem
{
    class Program
    {
        static void Main()
        {
            var myManager = new EventsManager();
            var myEngine = new Engine(myManager);

            string currentLine = Console.ReadLine();
            while (currentLine != "End")
            {
                var myCommand = new Command(currentLine);
                Console.WriteLine(myEngine.ProcessCommand(myCommand));
                currentLine = Console.ReadLine();
            }
        }
    }
}