using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Tank : Machine, ITank
    {
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints)
        {
            base.HealthPoints = 100;
            this.DefenseMode = true;
            this.ToggleDefenseMode();
        }

        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {
            if (this.DefenseMode)
            {
                this.DefenseMode = false;
                base.AttackPoints -= 40;
                base.DefensePoints += 30;
            }
            else
            {
                this.DefenseMode = true;
                base.AttackPoints += 40;
                base.DefensePoints -= 30;
            }
        }

        public override string ToString()
        {
            StringBuilder machineInfo = new StringBuilder();
            machineInfo.AppendLine(string.Format("- {0}", base.Name));
            machineInfo.AppendLine(string.Format(" *Type: Tank"));
            machineInfo.AppendLine(base.ToString());
            machineInfo.Append(string.Format(" *Defense: {0}", this.DefenseMode ? "OFF" : "ON"));
            return machineInfo.ToString();
        }
    }
}