using System;

using Computers.Components.Abstract;

namespace Computers.Components
{
    public class ColerfulVideoCard : VideoCard
    {
        public ColerfulVideoCard()
            : base(ConsoleColor.Green)
        {
        }

        public override void Draw(string argument)
        {
            base.Draw(argument);
        }
    }
}
