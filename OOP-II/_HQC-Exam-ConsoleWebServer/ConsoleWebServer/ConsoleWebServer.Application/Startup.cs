namespace ConsoleWebServer.Application
{
    public static class Startup
    {
        public static void Main()
        {
            var webServerConsole = new WebServerConsole();
            webServerConsole.Start();
        }
    }
}