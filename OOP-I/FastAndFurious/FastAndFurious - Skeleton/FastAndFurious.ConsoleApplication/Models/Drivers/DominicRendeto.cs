using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Drivers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Drivers
{
    public class DominicRendeto : Driver
    {
        private const string DominicRendetoName = "Dominic Rendeto";

        public DominicRendeto() 
            : base(DominicRendetoName, GenderType.Male)
        {
        }
    }
}
