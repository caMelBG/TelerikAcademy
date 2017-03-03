namespace HotelBookingSystem.Utilities
{
    using System;

    public static class Validator
    {
        public static void ValidateMinLength(string value, int minLength, string paramName)
        {
            if (string.IsNullOrEmpty(value) || value.Length < minLength)
            {
                throw new ArgumentException(string.Format("The {0} must be at least {1} symbols long.", paramName, minLength));
            }
        }

        public static void ValidateMinValue(int value, int minValue, string paramName)
        {
            if (value < minValue)
            {
                throw new ArgumentException(string.Format("The {0} must not be less than {1}.", paramName, minValue));
            }
        }

        public static void ValidateMinValue(decimal value, decimal minValue, string paramName)
        {
            if (value < minValue)
            {
                throw new ArgumentException(string.Format("The {0} must not be less than {1}.", paramName, minValue));
            }
        }

        public static void ValidateDateRange(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                throw new ArgumentException("The date range is invalid.");
            }
        }
    }
}
