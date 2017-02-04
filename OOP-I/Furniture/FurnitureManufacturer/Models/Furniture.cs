using System;
using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    public abstract class Furniture : IFurniture
    {
        private string model;
        private string materialType;
        private decimal price;
        private decimal height;

        public Furniture(string model, string materialType, decimal price, decimal height)
        {
            this.Model = model;
            this.Material = materialType;
            this.Price = price;
            this.Height = height;
        }

        public decimal Height
        {
            get
            {
                return this.height;
            }

            protected set
            {
                if (value > 0)
                {
                    this.height = value;
                }
            }
        }

        public string Material
        {
            get
            {
                return this.materialType;
            }

            protected set
            {
                this.materialType = value;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            protected set
            {
                if (value.Length >= 3 && !String.IsNullOrEmpty(value))
                {
                    this.model = value;
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value > 0)
                {
                    this.price = value;
                }
            }
        }

        public virtual string Print()
        {
            throw new NotImplementedException();
        }
    }
}
