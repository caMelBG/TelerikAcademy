using System;
using System.Text;
using WarMachines.Interfaces;

namespace WarMachines.Machines
{
    public class Fighter : Machine, IFighter
    {
        public Fighter(string name, double attackPoints, double defensePoints, bool stealthMode)
            : base(name, attackPoints, defensePoints)
        {
            this.StealthMode = stealthMode;
            base.HealthPoints = 200;
        }

        public bool StealthMode { get; private set; }

        public void ToggleStealthMode()
        {
            this.StealthMode = this.StealthMode
                ? false
                : true;
        }

        public override string ToString()
        {
            StringBuilder machineInfo = new StringBuilder();
            machineInfo.AppendLine(string.Format("- {0}", base.Name));
            machineInfo.AppendLine(string.Format(" *Type: Fighter"));
            machineInfo.AppendLine(base.ToString());
            machineInfo.Append(string.Format(" *Stealth: {0}", this.StealthMode ? "ON" : "OFF"));
            return machineInfo.ToString();
        }
    }
}
