using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Models.Common;

namespace FastAndFurious.ConsoleApplication.Models.Motors.Abstract
{
    public abstract class Motor : TunningPart, IMotor, ITunningPart, IAccelerateable, ITopSpeed, IWeightable, IValuable
    {
        public Motor(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed,
            int horsepower,
            TunningGradeType gradeType,
            CylinderType cylinderType,
            MotorType engineType)
            : base (price, weight, acceleration, topSpeed, gradeType)
        {
            this.CylinderType = cylinderType;
            this.EngineType = engineType;
        }

        public int Horsepower { get; set; }

        public MotorType EngineType { get; set; }

        public CylinderType CylinderType { get; set; }
    }
}
