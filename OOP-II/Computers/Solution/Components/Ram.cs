using Computers.Interfaces;

namespace Computers.Components
{
    public class Ram : IRam
    {
        public Ram(int amount)
        {
            this.Amount = amount;
        }

        public int Amount { get; private set; }

        public int Value { get; set; }

        public void SaveValue(int newValue)
        {
            this.Value = newValue;
        }

        public int LoadValue()
        {
            return this.Value;
        }
    }
}