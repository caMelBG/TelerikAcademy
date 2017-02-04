namespace VehicleParkSystem
{
    public class Car : Vehicle
    {
        public Car(string owner, string licensePlate, int reservedHours) 
            : base(owner, licensePlate, reservedHours)
        {
            this.RegularRate = 2.00m;
            this.OvertimeRate = 3.50m;
        }
    }
}
