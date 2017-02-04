using Computers.Components;
using Computers.Interfaces;

namespace Computers.Manufactory.Abstract
{
    public abstract class AbstractPC : Motherboard, IPC
    {
        public AbstractPC(ICpu cpu, IRam ram, IHardDrive hardDrive, IVideoCard videoCard) 
            : base(cpu, ram, hardDrive, videoCard)
        {
        }

        public void Play(int guessNumber)
        {
            var randomNumber = this.Cpu.Random(1, 10);
            this.Ram.SaveValue(randomNumber);
            if (randomNumber != guessNumber)
            {
                VideoCard.Draw(string.Format(
                    "You didn't guess the number {0}.",
                    randomNumber));
            }
            else
            {
                VideoCard.Draw("You win!");
            }
        }
    }
}
