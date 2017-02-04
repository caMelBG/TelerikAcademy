using Computers.Components;
using Computers.Manufactory.Abstract;

namespace Computers.Manufactory
{
    public class Lenovo
    {
        public class PC : AbstractPC
        {
            public PC()
                : base(new Cpu64(2),
                       new Ram(4),
                       new HardDrive(2000, false),
                       new MonochromeVideoCard())
            {
            }
        }

        public class Laptop : AbstractLaptop
        {
            public Laptop()
                : base(new Cpu64(2),
                       new Ram(16),
                       new HardDrive(1000, false),
                       new ColerfulVideoCard())
            {
            }
        }

        public class Server : AbstractServer
        {
            public Server()
                : base(new Cpu128(2),
                       new Ram(8),
                       new HardDrive(500, true))
            {
            }
        }
    }
}
