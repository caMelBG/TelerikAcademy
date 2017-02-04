namespace AcademyRPG
{
    public abstract class StaticObject : MovingObject
    {
        public StaticObject(Point position, int owner = 0)
            : base(position, owner)
        {
        }
    }
}
