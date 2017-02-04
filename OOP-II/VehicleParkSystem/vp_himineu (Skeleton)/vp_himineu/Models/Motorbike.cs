namespace VehicleParkSystem
{
    public class Motorbike : Vehicle
    {
        public Motorbike(string owner, string licensePlate, int reservedHours) 
            : base(owner, licensePlate, reservedHours)
        {
            this.RegularRate = 1.35m;
            this.OvertimeRate = 3.00m;
        }
    }
}
