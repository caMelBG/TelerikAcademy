using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class ConvertibleChair : Chair, IConvertibleChair
    {
        private bool isConverted;
        private decimal convertedHeight = 0.10m;

        public ConvertibleChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public bool IsConverted
        {
            get
            {
                return this.isConverted;
            }

            private set
            {
                this.isConverted = value;
            }
        }

        public void Convert()
        {
            this.isConverted = this.isConverted
                ? false
                : true;
            if (this.isConverted)
            {
                decimal middleState = base.Height;
                base.Height = this.convertedHeight;
                this.convertedHeight = middleState;
            }
        }

        public override string Print()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}, State: {6}",
                this.GetType().Name,
                this.Model, 
                this.Material, 
                this.Price, 
                this.Height, 
                this.NumberOfLegs, 
                this.IsConverted ? "Converted" : "Normal");
        }
    }
}