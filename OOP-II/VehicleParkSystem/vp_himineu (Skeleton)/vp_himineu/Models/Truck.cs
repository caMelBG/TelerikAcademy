namespace VehicleParkSystem
{
    public class Truck : Vehicle
    {
        public Truck(string owner, string licensePlate, int reservedHours)
            : base(owner, licensePlate, reservedHours)
        {
            this.RegularRate = 4.75m;
            this.OvertimeRate = 6.20m;
        }
    }
}
