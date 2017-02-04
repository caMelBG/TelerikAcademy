using Cosmetics.Contracts;
using System;
using System.Collections.Generic;

namespace Cosmetics.Products
{
    public class ShoppingCart : IShoppingCart
    {
        private List<IProduct> products;

        public ShoppingCart()
        {
            this.products = new List<IProduct>();
        }

        public void AddProduct(IProduct product)
        {
            products.Add(product);
        }

        public bool ContainsProduct(IProduct product)
        {
            if (products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public void RemoveProduct(IProduct product)
        {
            products.Remove(product);
        }

        public decimal TotalPrice()
        {
            decimal sumOfProductsPrices = 0;
            foreach (var product in products)
            {
                if (product.Price > 0)
                {
                     sumOfProductsPrices += product.Price;
                }

                else
                {
                    throw new NullReferenceException();
                }
            }

            return sumOfProductsPrices;
        }
    }
}