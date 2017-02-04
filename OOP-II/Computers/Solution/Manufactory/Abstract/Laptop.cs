using Computers.Components;
using Computers.Interfaces;

namespace Computers.Manufactory.Abstract
{
    public abstract class AbstractLaptop : Motherboard, ILaptop
    {
        public AbstractLaptop(ICpu cpu, IRam ram, IHardDrive hardDrive, IVideoCard videoCard)
            : base(cpu, ram, hardDrive, videoCard)
        {
            this.Battery = new LaptopBattery();
        }

        private LaptopBattery Battery { get; set; }

        public void ChargeBattery(int percentage)
        {
            this.Battery.Charge(percentage);
            this.VideoCard.Draw(string.Format("Battery status: {0}", this.Battery.Percentage));
        }
    }
}
