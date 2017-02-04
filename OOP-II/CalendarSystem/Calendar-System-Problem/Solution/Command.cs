using System;

namespace CalendarSystem
{
    public class Command
    {
        public string Name { get; set; }
        public string[] Paramms { get; set; }

        public Command(string commandToParse)
        {
            this.Parse(commandToParse);
        }

        private void Parse(string commandToParse)
        {
            int indexOfSeparator = commandToParse.IndexOf(' ');
            if (indexOfSeparator == -1)
            {
                throw new Exception("Invalid command: " + commandToParse);
            }

            this.Name = commandToParse.Substring(0, indexOfSeparator);

            string currentArgument = commandToParse.Substring(indexOfSeparator + 1);

            var commandArguments = currentArgument.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                currentArgument = commandArguments[i];
                commandArguments[i] = currentArgument.Trim();
            }

            this.Paramms = commandArguments;
        }
    }
}
