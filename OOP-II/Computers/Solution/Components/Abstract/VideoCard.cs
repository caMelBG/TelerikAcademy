using System;

using Computers.Interfaces;

namespace Computers.Components.Abstract
{
    public abstract class VideoCard : IVideoCard
    {
        private ConsoleColor color;

        protected VideoCard(ConsoleColor color)
        {
            this.color = color;
        }

        public virtual void Draw(string argument)
        {
            Console.ForegroundColor = this.color;
            Console.WriteLine(argument);
            Console.ResetColor();
        }
    }
}
