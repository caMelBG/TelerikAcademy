using System;
using Dealership.Contracts;
using System.Text;
using Dealership.Common.Enums;
using Dealership.Common;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar, IVehicle, ICommentable, IPriceable
    {
        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base (make, model, price, VehicleType.Car)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get
            {
                return this.seats;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value,
                    Constants.MinSeats,
                    Constants.MaxSeats,
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax,
                        Constants.MinSeats,
                        Constants.MaxSeats));
                this.seats = value;
            }
        }

        public override string Print()
        {
            StringBuilder carInfo = new StringBuilder();
            carInfo.Append("1. Car:");
            carInfo.AppendLine(base.Print());
            carInfo.AppendLine(String.Format("Seats: {0}", this.Seats));
            return carInfo.ToString().Trim();
        }
    }
}
