using System;
using ArmyOfCreatures.Logic.Battles;
using System.Collections.Generic;
using ArmyOfCreatures.Logic;
using System.Globalization;
using System.Linq;

namespace ArmyOfCreatures.Extended.Battles
{
    class ExtendBattleManager : BattleManager
    {
        private readonly ICollection<ICreaturesInBattle> thirdArmyCreatures;

        public ExtendBattleManager(ICreaturesFactory creaturesFactory, ILogger logger)
            : base (creaturesFactory, logger)
        {
            this.thirdArmyCreatures = new List<ICreaturesInBattle>();
        }

        public void AddCreatures(CreatureIdentifier creatureIdentifier, int count)
        {
            base.AddCreatures(creatureIdentifier, count);
        }

        public void Attack(CreatureIdentifier attackerIdentifier, CreatureIdentifier defenderIdentifier)
        {
            base.Attack(attackerIdentifier, defenderIdentifier);
        }

        public void Skip(CreatureIdentifier creatureIdentifier)
        {
            base.Skip(creatureIdentifier);
        }

        protected override void AddCreaturesByIdentifier(CreatureIdentifier creatureIdentifier, ICreaturesInBattle creaturesInBattle)
        {
            if (creatureIdentifier.ArmyNumber == 1 || creatureIdentifier.ArmyNumber == 2)
            {
                base.AddCreaturesByIdentifier(creatureIdentifier, creaturesInBattle);
                return;
            }

            if (creatureIdentifier == null)
            {
                throw new ArgumentNullException("creatureIdentifier");
            }

            if (creaturesInBattle == null)
            {
                throw new ArgumentNullException("creaturesInBattle");
            }

            if (creatureIdentifier.ArmyNumber == 3)
            {
                this.thirdArmyCreatures.Add(creaturesInBattle);
            }
            else
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", creatureIdentifier.ArmyNumber));
            }
        }

        protected override ICreaturesInBattle GetByIdentifier(CreatureIdentifier identifier)
        {
            
            if (identifier.ArmyNumber == 1 || identifier.ArmyNumber == 2)
            {
                return base.GetByIdentifier(identifier);
            }

            if (identifier == null)
            {
                throw new ArgumentNullException("identifier");
            }


            if (identifier.ArmyNumber == 3)
            {
                return this.thirdArmyCreatures
                    .FirstOrDefault(x => x.Creature.GetType()
                    .Name == identifier.CreatureType);
            }

            throw new ArgumentException(
                string.Format(CultureInfo.InvariantCulture, "Invalid ArmyNumber: {0}", identifier.ArmyNumber));
        }
    }
}
