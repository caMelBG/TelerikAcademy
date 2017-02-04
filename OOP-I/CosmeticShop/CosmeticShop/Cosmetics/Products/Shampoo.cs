﻿using Cosmetics.Contracts;
using Cosmetics.Common;
using System.Text;

namespace Cosmetics.Products
{
    public class Shampoo : Product, IShampoo, IProduct
    {
        private const int MinimumIngredientNameLength = 4;
        private const int MaximumIngredientNameLength = 12;
        
        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
            : base (name, brand,price, gender)
        {
            this.Milliliters = milliliters;
            this.Usage = usage;
        }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public override string Print()
        {
            StringBuilder productInformation = new StringBuilder();
            productInformation.AppendLine(string.Format("  * Quantity: {0} ml", this.Milliliters));
            productInformation.AppendLine(string.Format("  * Usage: {0}", this.Usage));
            return productInformation.ToString().Trim();
        }
    }
}