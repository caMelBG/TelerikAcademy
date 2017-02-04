namespace AcademyRPG
{
    public interface IDestroyable : IWorldObject
    {
        bool IsDestroyed
        {
            get;
        }
    }
}
