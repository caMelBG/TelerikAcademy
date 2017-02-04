using Computers.Components.Abstract;

namespace Computers.Components
{
    public class Cpu128 : Cpu
    {
        public Cpu128(int numberOfCores)
            : base(numberOfCores, 128)
        {
        }
    }
}
