namespace TradeAndTravel
{
    public class Iron : Item
    {
        private const int IronValue = 3;

        public Iron(string name, Location location = null)
            : base(name, IronValue, ItemType.Iron, location)
        {
        }

        public override void UpdateWithInteraction(string interaction)
        {
            return;
        }
    }
}
