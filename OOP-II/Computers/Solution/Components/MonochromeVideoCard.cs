using System;

using Computers.Components.Abstract;

namespace Computers.Components
{
    public class MonochromeVideoCard : VideoCard
    {
        public MonochromeVideoCard() : base(ConsoleColor.Gray)
        {
        }

        public override void Draw(string argument)
        {
            base.Draw(argument);
        }
    }
}
