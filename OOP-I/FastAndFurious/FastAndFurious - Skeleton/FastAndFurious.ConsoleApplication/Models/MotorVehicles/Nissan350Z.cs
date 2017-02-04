using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class Nissan350Z : MotorVehicle
    {
        private const decimal Nissan350ZPrice = 25999;
        private const int Nissan350ZWeight = 1280000;
        private const int Nissan350ZTopSpeed = 220;
        private const int Nissan350ZAcceleration = 55;

        public Nissan350Z() 
            : base(Nissan350ZPrice,
                   Nissan350ZWeight,
                   Nissan350ZTopSpeed,
                   Nissan350ZAcceleration)
        {
        }
    }
}
