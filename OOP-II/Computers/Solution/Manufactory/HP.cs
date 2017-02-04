using Computers.Components;
using Computers.Manufactory.Abstract;

namespace Computers.Manufactory
{
    public class HP
    {
        public class PC : AbstractPC
        {
            public PC() 
                : base(new Cpu32(2),
                       new Ram(2),
                       new HardDrive(500, false), 
                       new ColerfulVideoCard())
            {
            }
        }

        public class Laptop : AbstractLaptop
        {
            public Laptop() 
                : base(new Cpu64(2),
                       new Ram(4), 
                       new HardDrive(500, false),
                       new ColerfulVideoCard())
            {
            }
        }

        public class Server : AbstractServer
        {
            public Server()
                : base(new Cpu32(4),
                       new Ram(32), 
                       new HardDrive(1000, true))
            {
            }
        }
    }
}
