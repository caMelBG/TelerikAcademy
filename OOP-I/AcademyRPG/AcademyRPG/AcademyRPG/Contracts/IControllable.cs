namespace AcademyRPG
{
    public interface IControllable : IWorldObject, IDestroyable
    {
        string Name
        {
            get;
        }
    }
}
