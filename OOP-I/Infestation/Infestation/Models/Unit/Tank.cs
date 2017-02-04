namespace Infestation
{
    class Tank : Unit
    {
        private const int Health = 20;
        private const int Power = 25;
        private const int Aggression = 25;

        public Tank(string id) 
            : base(id, UnitClassification.Mechanical, 20, Power, Aggression)
        {
        }
    }
}
