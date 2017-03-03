namespace HotelBookingSystem.Models
{
    using System;
    using Contracts;
    using Utilities;

    public class Booking : IDbEntity
    {
        private decimal totalPrice;

        public Booking(User client, DateTime startBookDate, DateTime endBookDate, decimal totalPrice, string comments)
        {
            this.Client = client;
            this.StartBookDate = startBookDate;
            this.EndBookDate = endBookDate;
            Validator.ValidateDateRange(this.StartBookDate, this.EndBookDate);
            this.TotalPrice = totalPrice;
            this.Comments = comments;
        }

        public int Id { get; set; }

        public User Client { get; private set; }

        public DateTime StartBookDate { get; private set; }

        public DateTime EndBookDate { get; private set; }

        public decimal TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            private set
            {
                Validator.ValidateMinValue(value, 0, "total price");
                this.totalPrice = value;
            }
        }

        public string Comments { get; private set; }
    }
}