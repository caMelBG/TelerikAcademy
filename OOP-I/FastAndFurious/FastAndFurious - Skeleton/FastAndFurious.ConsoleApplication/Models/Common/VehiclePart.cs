using FastAndFurious.ConsoleApplication.Contracts;
using FastAndFurious.ConsoleApplication.Common.Utils;

namespace FastAndFurious.ConsoleApplication.Models.Common
{
    public abstract class VehiclePart : IVehiclePart
    {
        private readonly int id;

        public VehiclePart(
            decimal price,
            int weight,
            int acceleration,
            int topSpeed)
        {
            this.id = DataGenerator.GenerateId();
            this.Price = price;
            this.Weight = weight;
            this.Acceleration = acceleration;
            this.TopSpeed = topSpeed;
        }

        public int Acceleration { get; private set; }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public decimal Price { get; private set; }

        public int TopSpeed { get; private set; }

        public int Weight { get; private set; }
    }
}
