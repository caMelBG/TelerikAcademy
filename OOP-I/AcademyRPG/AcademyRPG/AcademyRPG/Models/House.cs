namespace AcademyRPG
{
    public class House : StaticObject, IDestroyable
    {
        public House(int owner, Point position)
            : base(position, owner)
        {
            this.HitPoints = 500;
        }
    }
}
