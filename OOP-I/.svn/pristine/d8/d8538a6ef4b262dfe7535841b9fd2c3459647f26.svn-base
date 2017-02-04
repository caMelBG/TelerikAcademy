using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract
{
    public class Intercooler : TunningPart, IIntercooler, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        public Intercooler(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            TunningGradeType gradeType,
            IntercoolerType intercoolerType)
            : base(price, weight, acceleration, topSpeed, gradeType)
        {
            this.IntercoolerType = intercoolerType;
        }

        public IntercoolerType IntercoolerType { get; private set; }
    }
}
