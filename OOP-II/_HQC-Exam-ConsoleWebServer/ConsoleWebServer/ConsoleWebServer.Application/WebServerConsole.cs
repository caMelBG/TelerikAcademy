namespace ConsoleWebServer.Application
{
    using System;
    using System.Text;

    using ConsoleWebServer.Framework;
    using System.IO;
    public class WebServerConsole
    {
        private readonly ResponseProvider responseProvider;

        public WebServerConsole()
        {
            this.responseProvider = new ResponseProvider();
        }

        public void Start()
        {
            var requestBuilder = new StringBuilder();
            var outputBuilder = new StringBuilder();
            string inputLine;
            while ((inputLine = Console.ReadLine()) != null)
            {
                if (string.IsNullOrWhiteSpace(inputLine))
                {
                    var response = this.responseProvider
                        .GetResponse(requestBuilder.ToString());

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(response);
                    Console.ResetColor();
                    outputBuilder.AppendLine(response.ToString());
                    requestBuilder.Clear();
                    continue;
                }

                requestBuilder.AppendLine(inputLine);
            }

            using (StreamWriter myWriter = new StreamWriter(@"..\..\..\output.txt"))
            {
                myWriter.WriteLine(outputBuilder);
                myWriter.WriteLine();
            }
        }
    }
}