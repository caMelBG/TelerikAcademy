namespace Computers.Components
{
    public class LaptopBattery
    {
        public LaptopBattery()
        {
            this.Percentage = 50;
        }

        public int Percentage { get; private set; }

        public void Charge(int power)
        {
            this.Percentage += power;
            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }
            else if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }
    }
}
