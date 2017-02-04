namespace TradeAndTravel
{
    public class Weapon : Item
    {
        private const int WeaponValue = 10;

        public Weapon(string name, Location location = null) 
            : base(name, WeaponValue, ItemType.Weapon, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            return;
        }
    }
}
