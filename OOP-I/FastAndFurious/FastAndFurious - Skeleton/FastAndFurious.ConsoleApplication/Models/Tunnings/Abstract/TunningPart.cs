using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Common
{
    public abstract class TunningPart : VehiclePart, ITunningPart
    {
        public TunningPart(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            TunningGradeType gradeType)
            : base(price, weight, acceleration, topSpeed)
        {
            this.GradeType = gradeType;
        }

        public TunningGradeType GradeType { get; private set; }    
    }
}
