namespace AcademyRPG
{
    public abstract class MovingObject : WorldObject, IDestroyable
    {
        public MovingObject(Point position, int owner)
            : base(position, owner)
        {
        }

        public void GoTo(Point destination)
        {
            this.Position = destination;
        }
    }
}
