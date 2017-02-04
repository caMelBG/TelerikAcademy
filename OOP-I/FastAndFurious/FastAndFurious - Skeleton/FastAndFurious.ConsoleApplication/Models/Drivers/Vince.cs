using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class Vince : Driver
    {
        private const string VinceName = "Vince";

        public Vince() 
            : base(VinceName, GenderType.Male)
        {
        }
    }
}
