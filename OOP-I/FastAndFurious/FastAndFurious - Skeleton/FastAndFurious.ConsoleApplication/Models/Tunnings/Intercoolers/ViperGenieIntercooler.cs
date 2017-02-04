using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Intercoolers
{
    public class ViperGenieIntercooler : Intercooler
    {
        private const decimal ViperGenieIntercoolerPrice = 289;
        private const int ViperGenieIntercoolerWeight = 5300;
        private const int ViperGenieIntercoolerAcceleration = 0;
        private const int ViperGenieIntercoolerTopSpeed = 25;

        public ViperGenieIntercooler() 
            : base(ViperGenieIntercoolerPrice,
                  ViperGenieIntercoolerWeight,
                  ViperGenieIntercoolerAcceleration,
                  ViperGenieIntercoolerTopSpeed,
                  TunningGradeType.MidGrade, 
                  IntercoolerType.ChargeAirIntercooler)
        {
        }
    }
}
