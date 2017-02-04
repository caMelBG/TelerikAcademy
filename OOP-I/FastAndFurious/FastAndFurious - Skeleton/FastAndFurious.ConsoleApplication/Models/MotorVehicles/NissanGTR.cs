using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class NissanGTR : MotorVehicle
    {
        private const decimal NissanGTRPrice = 125000;
        private const int NissanGTRWeight = 1850000;
        private const int NissanGTRTopSpeed = 300;
        private const int NissanGTRAcceleration = 45;

        public NissanGTR()
            : base(NissanGTRPrice,
                   NissanGTRWeight,
                   NissanGTRTopSpeed,
                   NissanGTRAcceleration)
        {
        }
    }
}
