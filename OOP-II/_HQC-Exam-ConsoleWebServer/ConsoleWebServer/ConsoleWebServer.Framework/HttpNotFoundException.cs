namespace ConsoleWebServer.Framework
{
    using System;

    public class HttpNotFoundException : Exception
    {
        public HttpNotFoundException(string message) : base(message)
        {
        }

        public class ParserException : Exception
        {
            public ParserException(string message, ActionDescriptor request = null)
                : base(message)
            {
            }
        }
    }
}