using System;
using System.Collections.Generic;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public abstract class Machine : IMachine
    {
        public Machine(string name, double attackPoints, double defensePoints)
        {
            this.Name = name;
            this.AttackPoints = attackPoints;
            this.DefensePoints = defensePoints;
            this.Targets = new List<string>();
        }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public double HealthPoints { get; set; }

        public string Name { get; set; }

        public IPilot Pilot { get; set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            this.Targets.Add(target.Name);
            if (this.AttackPoints >= target.DefensePoints)
            {
                double damage = this.AttackPoints - target.DefensePoints;
                target.HealthPoints -= damage;
            }
        }

        public override string ToString()
        {
            string targets = this.Targets.Count >= 1
                ? " *Targets: " + String.Join(", ", this.Targets)
                : " *Targets: None";
            StringBuilder machineInfo = new StringBuilder();
            machineInfo.AppendLine(string.Format(" *Health: {0}", this.HealthPoints));
            machineInfo.AppendLine(string.Format(" *Attack: {0}", this.AttackPoints));
            machineInfo.AppendLine(string.Format(" *Defense: {0}", this.DefensePoints));
            machineInfo.Append(targets);
            return machineInfo.ToString();
        }
    }
}
