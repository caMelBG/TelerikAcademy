using System;
using System.Collections.Generic;
using System.Linq;
using FastAndFurious.ConsoleApplication.Common.Constants;
using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Common.Utils;
using FastAndFurious.ConsoleApplication.Contracts;

namespace FastAndFurious.ConsoleApplication.Models.Drivers.Abstract
{
    public abstract class Driver : IDriver
    {
        private List<IMotorVehicle> currentVehicles;

        private readonly int id;

        public Driver(string name, GenderType gender)
        {
            currentVehicles = new List<IMotorVehicle>();
            this.id = DataGenerator.GenerateId();
            this.Name = name;
            this.Gender = gender;
        }

        public IMotorVehicle ActiveVehicle { get; private set; }

        public GenderType Gender { get; private set; }

        public int Id
        {
            get
            {
                return this.id;
            }
        }

        public string Name { get; private set; }

        public IEnumerable<IMotorVehicle> Vehicles { get { return new List<IMotorVehicle>(this.currentVehicles); } }

        public void AddVehicle(IMotorVehicle vehicle)
        {
            this.currentVehicles.Add(vehicle);
        }

        public bool RemoveVehicle(IMotorVehicle vehicle)
        {
            if (this.currentVehicles.Contains(vehicle))
            {
                this.currentVehicles.Remove(vehicle);
                return true;
            }

            return false;
        }

        public void SetActiveVehicle(IMotorVehicle vehicle)
        {
            if (currentVehicles.Contains(vehicle))
            {
                this.ActiveVehicle = vehicle;
            }
        }
    }
}
