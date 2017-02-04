namespace FurnitureManufacturer.Engine
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Interfaces.Engine;
    using System.IO;
    public class ConsoleRenderer : IRenderer
    {
        public IEnumerable<string> Input()
        {
            var currentLine = Console.ReadLine();
            while (!string.IsNullOrEmpty(currentLine))
            {
                yield return currentLine;
                currentLine = Console.ReadLine();
            }
        }

        public void Output(IEnumerable<string> output)
        {
            var result = new StringBuilder();
            foreach (var line in output)
            {
                result.AppendLine(line);
            }

            using(var myWriter = new StreamWriter(@"..\..\..\output.txt"))
            {
                myWriter.WriteLine(result.ToString());
            }
            Console.Write(result.ToString());
        }
    }
}
