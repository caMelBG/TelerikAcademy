using Computers.Interfaces;

namespace Computers.Components
{
    public class Motherboard : IMotherboard
    {
        public Motherboard(ICpu cpu, IRam ram, IHardDrive hardDrive, IVideoCard videoCard)
        {
            this.Cpu = cpu;
            this.Ram = ram;
            this.HardDrive = hardDrive;
            this.VideoCard = videoCard;
        }

        public ICpu Cpu { get; private set; }

        public IRam Ram { get; private set; }

        public IHardDrive HardDrive { get; private set; }

        public IVideoCard VideoCard { get; private set; }

        public void DrawOnVideoCard(string data)
        {
            this.VideoCard.Draw(data);
        }

        public int LoadRamValue()
        {
            return this.Ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.Ram.SaveValue(value);
        }
    }
}
