using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Pilot : IPilot
    {
        private ICollection<IMachine> machines;

        public Pilot(string name)
        {
            this.Name = name;
            this.machines = new List<IMachine>();
        }

        public string Name { get; private set; }

        public void AddMachine(IMachine machine)
        {
            machines.Add(machine);
        }

        public string Report()
        {
            var machineNumber = this.machines.Count > 0
                ? this.machines.Count.ToString()
                : "no";

            var machineString = "machines";
            if (this.machines.Count == 1)
            {
                machineString = "machine";
            }

            StringBuilder result = new StringBuilder();

            result.Append(String.Format("{0} - {1} {2}", 
                this.Name, 
                machineNumber, 
                machineString));

            var sortedMachines = this.machines
                .OrderBy(x => x.HealthPoints)
                .ThenBy(x => x.Name);

            foreach (var machine in this.machines)
            {
                result.AppendLine();
                if (machine != null)
                {
                    result.Append(machine.ToString());
                }
            }

            return result.ToString();
        }
    }
}