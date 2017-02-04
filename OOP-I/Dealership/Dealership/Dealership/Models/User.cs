using System;
using System.Collections.Generic;
using Dealership.Common.Enums;
using Dealership.Contracts;
using Dealership.Common;
using System.Text;

namespace Dealership.Models
{
    public class User : IUser
    {
        private string firstName;
        private string lastName;
        private string userName;
        private string password;

        public User(string username, string firstName, string lastName, string password, string role)
        {
            this.Username = userName;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.Role = (Role)Enum.Parse(typeof(Role), role);
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                Validator.ValidateIntRange(
                    value.Length,
                    Constants.MinNameLength,
                    Constants.MaxNameLength, 
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax, 
                        Constants.MinNameLength, 
                        Constants.MaxNameLength));
                Validator.ValidateNull(
                    value,
                    String.Format(
                        Constants.StringMustBeBetweenMinAndMax,
                        Constants.MinNameLength,
                        Constants.MaxNameLength));
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                Validator.ValidateIntRange(
                     value.Length,
                     Constants.MinNameLength,
                     Constants.MaxNameLength,
                     String.Format(
                         Constants.StringMustBeBetweenMinAndMax,
                         Constants.MinNameLength,
                         Constants.MaxNameLength));
                this.lastName = value;
            }
        }

        public string Password
        {
            get
            {
                return this.password;
            }

            private set
            {
                Validator.ValidateIntRange(
                     value.Length,
                     Constants.MinPasswordLength,
                     Constants.MaxPasswordLength,
                     String.Format(
                         Constants.StringMustBeBetweenMinAndMax,
                         Constants.MinPasswordLength,
                         Constants.MaxPasswordLength));
                this.password = value;
            }
        }

        public string Username
        {
            get
            {
                return this.userName;
            }

            private set
            {
                Validator.ValidateIntRange(
                     userName.Length,
                     Constants.MinNameLength,
                     Constants.MaxNameLength,
                     String.Format(
                         Constants.StringMustBeBetweenMinAndMax,
                         Constants.MinNameLength,
                         Constants.MaxNameLength));
                this.userName = value;
            }
        }
        
        public Role Role { get; private set; }

        public IList<IVehicle> Vehicles { get; private set; }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.Comments.Add(commentToAdd);
            commentToAdd.Author = this.Username;
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author == this.Username)
            {
                vehicleToRemoveComment.Comments.Remove(commentToRemove);
            }
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.Role == Role.Admin)
            {
                return;
            }
            else if (this.Role == Role.Normal || this.Vehicles.Count == Constants.MaxVehiclesToAdd)
            {
                return;
            }

            this.Vehicles.Add(vehicle);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.Vehicles.Remove(vehicle);
        }

        public string Print()
        {
            StringBuilder vehiclesInfo = new StringBuilder();
            vehiclesInfo.AppendFormat("--USER {0}--", this.Username);
            foreach (var vehicle in this.Vehicles)
            {
                vehiclesInfo.AppendLine(vehicle.Print());
                if (vehicle.Comments.Count == 0)
                {
                    vehiclesInfo.AppendLine("--NO COMMENTS--");
                    break;
                }

                foreach (var comment in vehicle.Comments)
                {
                    vehiclesInfo.AppendLine("--COMMENTS--");
                    vehiclesInfo.AppendLine("----------");
                    vehiclesInfo.AppendLine(comment.Content);
                    vehiclesInfo.AppendLine($"   User: {this.Username}");
                    vehiclesInfo.AppendLine("----------");
                    vehiclesInfo.AppendLine("--COMMENTS--");
                }
            }

            return vehiclesInfo.ToString();
        }
    }
}
