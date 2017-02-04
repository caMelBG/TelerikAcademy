using ArmyOfCreatures.Logic.Battles;
using ArmyOfCreatures.Logic.Specialties;
using System;
using System.Globalization;

namespace ArmyOfCreatures.Extended.Specialties
{
    public class DoubleDamage : Specialty
    {
        private readonly int rounds;

        public DoubleDamage(int rounds)
        {
            if (rounds < 1 || rounds > 10)
            {
                throw new ArgumentOutOfRangeException("rounds", "The number of rounds should be between 1 and 10, inclusive");
            }

            this.rounds = rounds;
        }

        public override decimal ChangeDamageWhenAttacking(ICreaturesInBattle attackerWithSpecialty, ICreaturesInBattle defender, decimal currentDamage)
        {
            if (attackerWithSpecialty == null)
            {
                throw new ArgumentNullException("attackerWithSpecialty");
            }

            if (defender == null)
            {
                throw new ArgumentNullException("defender");
            }

            if (this.rounds <= 0)
            {
                return currentDamage;
            }

            return currentDamage * 2M;
        }

        public override string ToString()
        {
            return string.Format(
               CultureInfo.InvariantCulture,
               "{0}({1})",
               base.ToString(),
               this.rounds);
        }
    }
}
