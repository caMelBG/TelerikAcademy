namespace Dealership.Contracts
{
    using Dealership.Common.Enums;

    public interface IVehicle : ICommentable, IPriceable, IPrintable
    {
        int Wheels { get; }

        VehicleType Type { get; }

        string Make { get; }

        string Model { get;  }
    }
}
