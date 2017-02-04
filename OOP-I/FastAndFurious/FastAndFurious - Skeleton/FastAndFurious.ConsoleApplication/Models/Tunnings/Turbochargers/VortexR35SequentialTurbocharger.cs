using FastAndFurious.ConsoleApplication.Common.Enums;
using FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.Tunnings.Turbochargers
{
    public class VortexR35SequentialTurbocharger : Turbocharger
    {
        private const decimal VortexR35SequentialTurbochargerPrice = 699;
        private const int VortexR35SequentialTurbochargerWeight = 3900;
        private const int VortexR35SequentialTurbochargerAcceleration = 10;
        private const int VortexR35SequentialTurbochargerTopSpeed = 85;

        public VortexR35SequentialTurbocharger() 
            : base(
                  VortexR35SequentialTurbochargerPrice,
                  VortexR35SequentialTurbochargerWeight,
                  VortexR35SequentialTurbochargerAcceleration,
                  VortexR35SequentialTurbochargerTopSpeed,
                  TunningGradeType.HighGrade, 
                  TurbochargerType.SequentialTurbo)
        {
        }
    }
}
