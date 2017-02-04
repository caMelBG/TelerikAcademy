namespace AcademyRPG
{
    public interface IWorldObject
    {
        int HitPoints { get; }

        int Owner { get; }

        Point Position { get; }
    }
}