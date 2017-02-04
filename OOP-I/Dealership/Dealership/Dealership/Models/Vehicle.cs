using System;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Common;
using System.Text;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle, ICommentable, IPriceable
    {
        private string make;
        private string model;
        private decimal price;
        private int wheels;

        protected Vehicle(string make, string model, decimal price, VehicleType type)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.Type = type;
            this.Wheels = (int)type;
        }

        public IList<IComment> Comments { get; private set; }

        public VehicleType Type { get; private set; }

        public string Make
        {
            get
            {
                return this.make;
            }

            private set
            {

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinMakeLength,
                    Constants.MaxMakeLength,
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax,
                        Constants.MinMakeLength,
                        Constants.MaxMakeLength));
                this.make = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {

                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinModelLength,
                    Constants.MaxModelLength,
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax,
                        Constants.MinModelLength,
                        Constants.MaxModelLength));
                this.model = value;
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            private set
            {

                Validator.ValidateDecimalRange(
                    value,
                    Constants.MinPrice,
                    Constants.MaxPrice,
                    String.Format(
                        Constants.NumberMustBeBetweenMinAndMax,
                        Constants.MinPrice,
                        Constants.MaxPrice));
                this.price = value;
            }
        }

        public int Wheels
        {
            get
            {
                return this.wheels;
            }

            private set
            {

                Validator.ValidateIntRange(
                    value,
                    Constants.MinWheels,
                    Constants.MaxWheels,
                    String.Format(
                        Constants.NumberMustBeBetweenMinAndMax,
                        Constants.MinWheels,
                        Constants.MaxWheels));
                this.wheels = value;
            }
        }

        public virtual string Print()
        {
            StringBuilder vehicleInfo = new StringBuilder();
            vehicleInfo.Append(String.Format("Make: {0}", this.Make));
            vehicleInfo.AppendLine(String.Format("Model: {0}", this.Model));
            vehicleInfo.AppendLine(String.Format("Wheels: {0}", this.Wheels));
            vehicleInfo.AppendLine(String.Format("Price: ${0}", this.Price));
            return vehicleInfo.ToString();
        }
    }
}
