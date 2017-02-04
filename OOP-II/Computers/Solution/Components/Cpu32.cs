using Computers.Components.Abstract;

namespace Computers.Components
{
    public class Cpu32 : Cpu
    {
        public Cpu32(int numberOfCores)
            : base(numberOfCores, 32)
        {
        }
    }
}
