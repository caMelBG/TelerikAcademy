using System;
using Dealership.Contracts;
using System.Text;
using Dealership.Common.Enums;
using Dealership.Common;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle , IMotorcycle, IVehicle, ICommentable, IPriceable
    {
        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base (make, model, price, VehicleType.Motorcycle)
        {
            this.Category = category;
        }

        public string Category
        {
            get
            {
                return this.category;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinCategoryLength,
                    Constants.MaxCategoryLength,
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax,
                        Constants.MinCategoryLength,
                        Constants.MaxCategoryLength));
                this.category = value;
            }
        }

        public override string Print()
        {
            StringBuilder motorcycleInfo = new StringBuilder();
            motorcycleInfo.Append("1. MotorCycle:");
            motorcycleInfo.AppendLine(base.Print());
            motorcycleInfo.AppendLine(string.Format("Category: {0}", this.Category));
            return motorcycleInfo.ToString().Trim();
        }
    }
}
