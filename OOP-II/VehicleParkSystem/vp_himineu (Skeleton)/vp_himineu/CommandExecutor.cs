namespace VehicleParkSystem
{
    using System;

    using Interfaces;

    public class CommandExecutor
    {
        private VehiclePark VehiclePark { get; set; }
        
        public string Execute(ICommand command)
        {
            if (command.Name != "SetupPark" && VehiclePark == null)
            {
                return "The vehicle park has not been set up";
            }
            switch (command.Name)
            {
                case "SetupPark":
                    var sectors = int.Parse(command.Parametars["sectors"]);
                    var placesPerSector = int.Parse(command.Parametars["placesPerSector"]);
                    this.VehiclePark = new VehiclePark(sectors, placesPerSector);
                    return "Vehicle park created";

                case "Park": return this.Park(command);

                case "Exit":
                    var licensePlate = command.Parametars["licensePlate"];
                    var time = DateTime.Parse(command.Parametars["time"]);
                    var money = decimal.Parse(command.Parametars["paid"]);
                    return this.VehiclePark.ExitVehicle(licensePlate, time, money);

                case "Status":
                    return VehiclePark.GetStatus();

                case "FindVehicle":
                    return VehiclePark.FindVehicle(command.Parametars["licensePlate"]);

                case "VehiclesByOwner":
                    return VehiclePark.FindVehiclesByOwner(command.Parametars["owner"]);

                default: throw new IndexOutOfRangeException("Invalid command.");
            }
        }

        private string Park(ICommand command)
        {
            var type = command.Parametars["type"];
            var licensePlate = command.Parametars["licensePlate"];
            var owner = command.Parametars["owner"];
            var hours = int.Parse(command.Parametars["hours"]);
            var sector = int.Parse(command.Parametars["sector"]);
            var place = int.Parse(command.Parametars["place"]);
            var time = DateTime.Parse(command.Parametars["time"]);

            if (type == "car")
            {
                return this.VehiclePark.InsertCar(
                    new Car(licensePlate, owner, hours), sector, place, time);
            }
            else if (type == "motorbike")
            {
                return this.VehiclePark.InsertMotorbike(
                    new Motorbike(licensePlate, owner, hours), sector, place, time);
            }
            else if (type == "truck")
            {
                return this.VehiclePark.InsertTruck(
                    new Truck(licensePlate, owner, hours), sector, place, time);
            }
            else
            {
                throw new IndexOutOfRangeException("Invalid command.");
            }
        }
    }}