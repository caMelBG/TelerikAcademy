namespace VehicleParkSystem
{
    using System.Collections.Generic;
    using Interfaces;
    using System;
    using System.Linq;
    using System.Text;

    public class VehiclePark : IVehiclePark
    {
        public Layout layout;
        public DataBase dataBase;
        public VehiclePark(int numberOfSectors, int placesPerSector)
        {
            layout = new Layout(numberOfSectors, placesPerSector);
            dataBase = new DataBase(numberOfSectors);
        }

        public string InsertCar(Car car, int sector, int place, DateTime time)
        {
            if (sector > layout.NumberOfSectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (dataBase.VehiclePark.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (dataBase.VehicleByLicensePlate.ContainsKey(car.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park",
                    car.LicensePlate);
            }

            dataBase.VehiclesInPark[car] = string.Format("({0},{1})", sector, place);
            dataBase.VehiclePark[string.Format("({0},{1})", sector, place)] = car;
            dataBase.VehicleByLicensePlate[car.LicensePlate] = car;
            dataBase.TimeByVehicle[car] = time;
            dataBase.VehicleByOwner[car.Owner].Add(car);
            dataBase.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})",
                car.GetType().Name, sector, place);
        }

        public string InsertMotorbike(Motorbike motorbike, int sector, int place, DateTime time)
        {
            if (sector > layout.NumberOfSectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (dataBase.VehiclePark.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (dataBase.VehicleByLicensePlate.ContainsKey(motorbike.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park",
                    motorbike.LicensePlate);
            }

            dataBase.VehiclesInPark[motorbike] = string.Format("({0},{1})", sector, place);
            dataBase.VehiclePark[string.Format("({0},{1})", sector, place)] = motorbike;
            dataBase.VehicleByLicensePlate[motorbike.LicensePlate] = motorbike;
            dataBase.TimeByVehicle[motorbike] = time;
            dataBase.VehicleByOwner[motorbike.Owner].Add(motorbike);
            dataBase.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})",
                motorbike.GetType().Name, sector, place);
        }

        public string InsertTruck(Truck truck, int sector, int place, DateTime time)
        {
            if (sector > layout.NumberOfSectors)
            {
                return string.Format("There is no sector {0} in the park", sector);
            }

            if (place > layout.PlacesPerSector)
            {
                return string.Format("There is no place {0} in sector {1}", place, sector);
            }

            if (dataBase.VehiclePark.ContainsKey(string.Format("({0},{1})", sector, place)))
            {
                return string.Format("The place ({0},{1}) is occupied", sector, place);
            }

            if (dataBase.VehicleByLicensePlate.ContainsKey(truck.LicensePlate))
            {
                return string.Format("There is already a vehicle with license plate {0} in the park",
                    truck.LicensePlate);
            }

            dataBase.VehiclesInPark[truck] = string.Format("({0},{1})", sector, place);
            dataBase.VehiclePark[string.Format("({0},{1})", sector, place)] = truck;
            dataBase.VehicleByLicensePlate[truck.LicensePlate] = truck;
            dataBase.TimeByVehicle[truck] = time;
            dataBase.VehicleByOwner[truck.Owner].Add(truck);
            dataBase.Count[sector - 1]++;

            return string.Format("{0} parked successfully at place ({1},{2})",
                truck.GetType().Name, sector, place);
        }

        public string ExitVehicle(string licensePlate, DateTime endTime, decimal money)
        {
            var vehicle = (dataBase.VehicleByLicensePlate.ContainsKey(licensePlate))
                ? dataBase.VehicleByLicensePlate[licensePlate]
                : null;

            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park",
                    licensePlate);
            }

            var start = dataBase.TimeByVehicle[vehicle];
            int end = (int)Math.Round((endTime - start).TotalHours);
            var ticket = new StringBuilder();

            ticket.AppendLine(new string('*', 20))
                .AppendFormat("{0}", vehicle.ToString())
                .AppendLine().AppendFormat("at place {0}", dataBase.VehiclesInPark[vehicle])
                .AppendLine().AppendFormat("Rate: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate))
                .AppendLine().AppendFormat("Overtime rate: ${0:F2}", (end > vehicle.ReservedHours ? (end - vehicle.ReservedHours) * vehicle.OvertimeRate : 0))
                .AppendLine().AppendLine(new string('-', 20))
                .AppendFormat("Total: ${0:F2}", (vehicle.ReservedHours * vehicle.RegularRate + (end > vehicle.ReservedHours ? (end - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine().AppendFormat("Paid: ${0:F2}", money)
                .AppendLine().AppendFormat("Change: ${0:F2}", money - ((vehicle.ReservedHours * vehicle.RegularRate) + (end > vehicle.ReservedHours ? (end - vehicle.ReservedHours) * vehicle.OvertimeRate : 0)))
                .AppendLine().Append(new string('*', 20));

            int sector = int.Parse(dataBase.VehiclesInPark[vehicle].Split(new[] { "(", ",", ")" },
                StringSplitOptions.RemoveEmptyEntries)[0]);

            dataBase.VehiclePark.Remove(dataBase.VehiclesInPark[vehicle]);
            dataBase.VehiclesInPark.Remove(vehicle);
            dataBase.VehicleByLicensePlate.Remove(vehicle.LicensePlate);
            dataBase.TimeByVehicle.Remove(vehicle);
            dataBase.VehicleByOwner.Remove(vehicle.Owner, vehicle);
            dataBase.Count[sector - 1]--;

            return ticket.ToString();
        }

        public string GetStatus()
        {
            var places = dataBase.Count.Select((placesUsed, sectorNumber) =>
            string.Format("Sector {0}: {1} / {2} ({3}% full)",
            sectorNumber + 1,
            placesUsed,
            layout.PlacesPerSector,
            Math.Round((double)placesUsed / layout.PlacesPerSector * 100)));

            return string.Join(Environment.NewLine, places);
        }

        public string FindVehicle(string licensePlate)
        {
            var vehicle = (dataBase.VehicleByLicensePlate.ContainsKey(licensePlate))
                ? dataBase.VehicleByLicensePlate[licensePlate]
                : null;

            if (vehicle == null)
            {
                return string.Format("There is no vehicle with license plate {0} in the park"
                    , licensePlate);
            }
            else
            {
                return Input(new[] { vehicle });
            }
        }

        public string FindVehiclesByOwner(string owner)
        {
            if (!dataBase.VehiclePark.Values.Where(v => v.Owner == owner).Any())
            {
                return string.Format("No vehicles by {0}", owner);
            }
            else
            {
                var founds = dataBase.VehiclePark.Values
                    .Where(v => v.Owner == owner)
                    .ToList();

                return string.Join(Environment.NewLine, Input(founds));
            }
        }

        private string Input(IEnumerable<IVehicle> vehicles)
        {
            return string.Join(Environment.NewLine, vehicles.Select(vehicle =>
            string.Format("{0}{1}Parked at {2}", vehicle.ToString(),
            Environment.NewLine, dataBase.VehiclesInPark[vehicle])));
        }
    }
}
