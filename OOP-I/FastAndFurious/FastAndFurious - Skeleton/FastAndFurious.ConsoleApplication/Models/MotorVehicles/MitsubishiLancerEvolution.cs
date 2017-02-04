using FastAndFurious.ConsoleApplication.Models.MotorVehicles.Abstract;

namespace FastAndFurious.ConsoleApplication.Models.MotorVehicles
{
    public class MitsubishiLancerEvolution : MotorVehicle
    {
        private const decimal MitsubishiLancerEvolutionPrice = 56999;
        private const int MitsubishiLancerEvolutionWeight = 1780000;
        private const int MitsubishiLancerEvolutionTopSpeed = 300;
        private const int MitsubishiLancerEvolutionAcceleration = 20;

        public MitsubishiLancerEvolution() 
            : base(MitsubishiLancerEvolutionPrice,
                  MitsubishiLancerEvolutionWeight,
                  MitsubishiLancerEvolutionTopSpeed,
                  MitsubishiLancerEvolutionAcceleration)
        {
        }
    }
}
