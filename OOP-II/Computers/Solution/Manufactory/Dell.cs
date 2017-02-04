using Computers.Components;
using Computers.Manufactory.Abstract;

namespace Computers.Manufactory
{
    public class Dell
    {
        public class PC : AbstractPC
        {
            public PC()
                : base(new Cpu64(4),
                       new Ram(8),
                       new HardDrive(1000, false), 
                       new ColerfulVideoCard())
            {
            }
        }

        public class Laptop : AbstractLaptop
        {
            public Laptop()
                : base(new Cpu32(4),
                       new Ram(8), 
                       new HardDrive(1000, false), 
                       new ColerfulVideoCard())
            {
            }
        }

        public class Server : AbstractServer
        {
            public Server()
                : base(new Cpu64(8),
                       new Ram(64),
                       new HardDrive(2000, true))
            {
            }
        }
    }
}
