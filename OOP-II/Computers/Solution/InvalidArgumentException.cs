using System;

namespace Computers
{
    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException(string message) 
            : base(message)
        {
        }
    }
}
