using FurnitureManufacturer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FurnitureManufacturer.Models
{
    public class Company : ICompany
    {
        private string name;
        private string registrationNumber;

        public Company(string name, string registrationNumber)
        {
            this.Name = name;
            this.RegistrationNumber = registrationNumber;
            this.Furnitures = new List<IFurniture>();
        }

        public ICollection<IFurniture> Furnitures { get; private set; }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value.Length >= 5 && !String.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
            }
        }

        public string RegistrationNumber
        {
            get
            {
                return this.registrationNumber;
            }

            private set
            {
                if (value.Length == 10 && !String.IsNullOrEmpty(value))
                {
                    this.registrationNumber = value;
                }
            }
        }

        public void Add(IFurniture furniture)
        {
            this.Furnitures.Add(furniture);
        }

        public void Remove(IFurniture furniture)
        {
            this.Furnitures.Remove(furniture);
        }

        public IFurniture Find(string model)
        {
            foreach (var furniture in this.Furnitures)
            {
                if (furniture.Model == model)
                {
                    return furniture;
                }
            }

            return null;
        }

        public string Catalog()
        {
            var orderedFurnitures = Furnitures
                .OrderBy(f => f.Price)
                .ThenBy(f => f.Model)
                .ToList();

            StringBuilder catalogInfo = new StringBuilder();

            if (orderedFurnitures.Count == 0)
            {
                return string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                "no",
                "furnitures");
            }
            else if (orderedFurnitures.Count == 1)
            {
                catalogInfo.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                "1",
                "furniture"));
            }
            catalogInfo.AppendLine(string.Format("{0} - {1} - {2} {3}",
                this.Name,
                this.RegistrationNumber,
                orderedFurnitures.Count.ToString(),
                "furnitures"));

            foreach (var furniture in orderedFurnitures)
            {
                catalogInfo.AppendLine(furniture.Print());
            }

            return catalogInfo.ToString().Trim();
        }
    }
}

