using FurnitureManufacturer.Interfaces;

namespace FurnitureManufacturer.Models
{
    class AdjustableChair : Chair, IAdjustableChair
    {
        public AdjustableChair(string model, string materialType, decimal price, decimal height, int numberOfLegs)
            : base(model, materialType, price, height, numberOfLegs)
        {
        }

        public void SetHeight(decimal height)
        {
            if (height > 0)
            {
                base.Height = height;
            }
        }

        public override string Print()
        {
            return string.Format("Type: {0}, Model: {1}, Material: {2}, Price: {3}, Height: {4}, Legs: {5}",
                this.GetType().Name,
                this.Model,
                this.Material,
                this.Price,
                this.Height,
                this.NumberOfLegs);
        }
    }
}
