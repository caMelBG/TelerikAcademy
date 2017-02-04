namespace AcademyEcosystem
{
    public class Boar : Animal, IHerbivore, ICarnivore
    {
        private const int BoarSize = 4;
        private const int BoarBiteSize = 2;

        public Boar(string name, Point location)
            : base(name, location, BoarSize)
        {
            this.IsAlive = true;
        }

        public int EatPlant(Plant plant)
        {
            if (plant != null)
            {
                return plant.GetEatenQuantity(BoarBiteSize);
            }

            return 0;
        }

        public int TryEatAnimal(Animal animal)
        {
            if (animal != null)
            {
                if (animal is Zombie)
                {
                    return animal.GetMeatFromKillQuantity();
                }
                else if (this.Size >= animal.Size || 
                    animal.State == AnimalState.Sleeping ||
                    animal is Zombie)
                {
                    return animal.GetMeatFromKillQuantity();
                }
            }

            return 0;
        }
    }
}
