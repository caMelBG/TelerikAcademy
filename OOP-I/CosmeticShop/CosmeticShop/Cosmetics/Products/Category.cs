using System;
using System.Linq;
using System.Collections.Generic;
using Cosmetics.Contracts;
using Cosmetics.Common;
using System.Text;

namespace Cosmetics.Products
{
    public class Category : ICategory
    {
        private const int MinimumNameLength = 2;
        private const int MaximumNameLength = 15;
        private const string CategoryName = "Category name";
        private const string ProductNotFound = "Product {0} does not exist in category {1}!";

        private string name;
        private List<IProduct> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<IProduct>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length >= MinimumNameLength &&
                    value.Length <= MaximumNameLength)
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException(string.Format(GlobalErrorMessages
                        .InvalidStringLength, CategoryName, MinimumNameLength, MaximumNameLength));
                }
            }
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.products.Add(cosmetics);
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (this.products.Contains(cosmetics))
            {
                this.products.Remove(cosmetics);
            }

            else
            {
                throw new NullReferenceException(string.Format(ProductNotFound, cosmetics.Name, this.Name));
            }
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            this.products = this.products
                .OrderBy(x => x.Name)
                .OrderByDescending(x => x.Price)
                .ToList();

            var outputLine = this.products.Count == 1
                ? String.Format("{0} category – {1} product in total", this.Name, this.products.Count)
                : String.Format("{0} category – {1} products in total", this.Name, this.products.Count);
            result.AppendLine(outputLine);

            foreach (var product in products)
            {
                result.AppendLine(String.Format("- {0} – {1}:", product.Brand, product.Name));
                result.AppendLine(String.Format("  * Price: ${0}", product.Price));
                result.AppendLine(String.Format("  * For gender: {0}", product.Gender));
                result.AppendLine(product.Print());
            }    
            return result.ToString().TrimEnd();
        }
    }
}
