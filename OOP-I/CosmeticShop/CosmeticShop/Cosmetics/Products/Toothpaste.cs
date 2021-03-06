﻿using System;
using System.Linq;
using Cosmetics.Contracts;
using Cosmetics.Common;
using System.Collections.Generic;
using System.Text;

namespace Cosmetics.Products
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int MinimumIngredientsNameLength = 4;
        private const int MaximumIngredientsNameLength = 12;

        public Toothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
            : base(name, brand, price, gender)
        {
            var tempList = ingredients
                .Where(x => x.ToString().Length >= 4 && x.ToString().Length <= 12)
                .ToList();
            this.Ingredients = String.Join(", ", tempList).ToString();
        }

        public string Ingredients { get; set; }

        public override string Print()
        {
            StringBuilder productInformation = new StringBuilder();
            productInformation.AppendLine(string.Format("  * Ingredients: {0}", this.Ingredients));
            return productInformation.ToString().Trim();
        }
    }
}