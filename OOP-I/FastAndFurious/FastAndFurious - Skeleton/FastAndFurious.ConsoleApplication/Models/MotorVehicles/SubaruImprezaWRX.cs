using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class SubaruImprezaWRX : MotorVehicle
    {
        private const decimal SubaruImprezaWRXPrice = 55999;
        private const int SubaruImprezaWRXWeight = 1560000;
        private const int SubaruImprezaWRXTopSpeed = 260;
        private const int SubaruImprezaWRXAcceleration = 35;

        public SubaruImprezaWRX()
            : base(SubaruImprezaWRXPrice,
                   SubaruImprezaWRXWeight,
                   SubaruImprezaWRXTopSpeed,
                   SubaruImprezaWRXAcceleration)
        {
        }
    }
}
