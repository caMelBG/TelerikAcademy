namespace VehicleParkSystem
{
    using System;
    using System.Collections.Generic;
    using VehicleParkSystem.Interfaces;
    using Wintellect.PowerCollections;

    public class DataBase
    {
        public DataBase(int numberOfSectors)
        {
            VehiclesInPark = new Dictionary<IVehicle, string>();
            VehiclePark = new Dictionary<string, IVehicle>();
            VehicleByLicensePlate = new Dictionary<string, IVehicle>();
            TimeByVehicle = new Dictionary<IVehicle, DateTime>();
            VehicleByOwner = new MultiDictionary<string, IVehicle>(false);
            Count = new int[numberOfSectors];
        }
        public Dictionary<IVehicle, string> VehiclesInPark { get; set; }

        public Dictionary<string, IVehicle> VehiclePark { get; set; }

        public Dictionary<string, IVehicle> VehicleByLicensePlate { get; set; }

        public Dictionary<IVehicle, DateTime> TimeByVehicle { get; set; }

        public MultiDictionary<string, IVehicle> VehicleByOwner { get; set; }

        public int[] Count { get; set; }

    }
}
