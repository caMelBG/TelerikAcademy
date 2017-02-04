using System.Collections.Generic;

namespace VehicleParkSystem.Interfaces
{
    public interface ICommand
    {
        string Name { get; }

        IDictionary<string, string> Parametars { get; }
    }
}
