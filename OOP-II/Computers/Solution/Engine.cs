using System;

using Computers.Interfaces;
using Computers.Manufactory;

namespace Computers
{
    public class Engine
    {
        private Engine()
        {
        }

        public static Engine Instance()
        {
            return new Engine();
        }

        public void Start()
        {
            IPC pc;
            ILaptop laptop;
            IServer server;
            var cuurrentLine = Console.ReadLine();
            switch (cuurrentLine)
            {
                case "HP":
                    pc = new HP.PC();
                    laptop = new HP.Laptop();
                    server = new HP.Server();
                    break;
                case "Dell":
                    pc = new Dell.PC();
                    laptop = new Dell.Laptop();
                    server = new Dell.Server();
                    break;
                case "Lenovo":
                    pc = new Lenovo.PC();
                    laptop = new Lenovo.Laptop();
                    server = new Lenovo.Server();
                    break;
                default:
                    throw new InvalidArgumentException("Invalid manufacturer!");
            }

            cuurrentLine = Console.ReadLine();
            while (!cuurrentLine.StartsWith("Exit"))
            {
                var commandParametars = cuurrentLine.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (commandParametars.Length != 2)
                {
                    throw new ArgumentException("Invalid command!");
                }

                var commandName = commandParametars[0];
                var commandArgument = int.Parse(commandParametars[1]);
                switch (commandName)
                {
                    case "Charge":
                        laptop.ChargeBattery(commandArgument);
                        break;
                    case "Process":
                        server.Process(commandArgument);
                        break;
                    case "Play":
                        pc.Play(commandArgument);
                        break;
                    default:
                        throw new ArgumentException("Invalid command!");
                }

                cuurrentLine = Console.ReadLine();
            }
        }
    }
}
