using Computers.Components.Abstract;

namespace Computers.Components
{
    public class Cpu64 : Cpu
    {
        public Cpu64(int numberOfCores)
            : base(numberOfCores, 64)
        {
        }
    }
}
