using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract
{
    public abstract class Turbocharger : TunningPart, ITurbocharger, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        public Turbocharger(
            decimal price, 
            int weight,
            int acceleration,
            int topSpeed, 
            TunningGradeType gradeType, 
            TurbochargerType turbochargerType)
            : base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.TurbochargerType = turbochargerType;
        }

        public TurbochargerType TurbochargerType { get; private set; }
    }
}
