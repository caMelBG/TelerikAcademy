namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Utilities;

    public class Room : IDbEntity
    {
        private int places;
        private decimal pricePerDay;

        public Room(int places, decimal pricePerDay)
        {
            this.Places = places;
            this.PricePerDay = pricePerDay;
            this.Bookings = new List<Booking>();
            this.AvailableDates = new List<AvailableDate>();
        }

        public int Id { get; set; }

        public int Places
        {
            get
            {
                return this.places;
            }

            private set
            {
                Validator.ValidateMinValue(value, 0, "places");
                this.places = value;
            }
        }

        public decimal PricePerDay
        {
            get
            {
                return this.pricePerDay;
            }

            private set
            {
                Validator.ValidateMinValue(value, 0, "price per day");
                this.pricePerDay = value;
            }
        }

        public ICollection<AvailableDate> AvailableDates { get; private set; }

        public ICollection<Booking> Bookings { get; private set; }
    }
}