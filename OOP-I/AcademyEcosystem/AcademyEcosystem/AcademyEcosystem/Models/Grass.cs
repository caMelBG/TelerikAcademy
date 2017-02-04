namespace AcademyEcosystem
{
    public class Grass : Plant
    {
        private const int GrassSize = 2;

        public Grass(Point location)
            : base(location, GrassSize)
        {
            this.IsAlive = true;
        }

        public override void Update(int timeElapsed)
        {
            this.Size += timeElapsed;
        }
    }
}
