namespace VehicleParkSystem
{
    using VehicleParkSystem.Interfaces;

    public class Vehicle : IVehicle
    {
        public Vehicle(string licensePlate, string owner, int reservedHours)
        {
            this.LicensePlate = licensePlate;
            this.Owner = owner;
            this.ReservedHours = reservedHours;
        }

        public string Owner { get; private set; }

        public string LicensePlate { get; private set; }
                
        public int ReservedHours { get; private set; }

        public decimal RegularRate { get; protected set; }

        public decimal OvertimeRate { get; protected set; }

        public override string ToString()
        {
            return string.Format("{0} [{1}], owned by {2}", 
                this.GetType().Name, this.LicensePlate, this.Owner);
        }
    }
}
