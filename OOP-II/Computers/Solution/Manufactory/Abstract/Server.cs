using Computers.Components;
using Computers.Interfaces;

namespace Computers.Manufactory.Abstract
{
    public abstract class AbstractServer : Motherboard, IServer
    {
        public AbstractServer(ICpu cpu, IRam ram, IHardDrive hardDrive) 
            : base(cpu, ram, hardDrive, new MonochromeVideoCard())
        {
        }

        public void Process(int data)
        {
            this.Cpu.SquareNumber(data);
        }
    }
}
