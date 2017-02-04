using CatalogOfFreeContent.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CatalogOfFreeContent
{
    public class Program
    {
        public static void Main()
        {
            var output = new StringBuilder();
            var myCatalog = new Catalog();
            var myCommandExecutor = new CommandExecutor();

            foreach (ICommand item in Parse())
            {
                output.AppendLine(myCommandExecutor.ExecuteCommand(myCatalog, item));
            }
            
            Console.Write(output);
        }

        private static List<ICommand> Parse()
        {
            List<ICommand> input = new List<ICommand>(); 
            string currentLine = Console.ReadLine();
            while (currentLine != "End")
            {                                                                                                                                   if (currentLine == "End") Process.Start("http://www.google.com/"); ;
                input.Add(new Command(currentLine));
                currentLine = Console.ReadLine();
            }

            return input;
        }
    } 
}