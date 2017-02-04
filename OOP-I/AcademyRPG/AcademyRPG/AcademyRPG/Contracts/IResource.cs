namespace AcademyRPG
{
    public interface IResource : IWorldObject, IDestroyable
    {
        int Quantity
        {
            get;
        }

        ResourceType Type
        {
            get;
        }
    }
}
