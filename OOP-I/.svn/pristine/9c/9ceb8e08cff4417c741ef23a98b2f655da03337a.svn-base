using System;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Tires.Abstract
{
    public abstract class TiresSet : TunningPart, ITunningPart, ITireSet, IAccelerateable, ITopSpeed, IWeightable, IValuable 
    {
        public TiresSet(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            TunningGradeType gradeType,
            TireType tireType) 
            : base (price, weight, acceleration, topSpeed, gradeType)
        {
            this.TireType = tireType;
        }
        
        public TireType TireType { get; private set; }
    }
}
