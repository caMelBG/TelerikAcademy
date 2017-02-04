using System;
using System.Collections.Generic;

namespace AcademyRPG
{
    public class Giant : Character, IFighter, IGatherer, INameable
    {
        private bool isGathed;

        private int attackPoints;

        public Giant(string name, Point position, int owner = 0)
            : base(name, position, owner)
        {
            this.HitPoints = 200;
            this.AttackPoints = 150;
            this.DefensePoints = 80;
            this.isGathed = false;
        }

        public int AttackPoints {
            get
            {
                if (isGathed)
                {
                    return this.attackPoints + 100;
                }

                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (!isGathed)
            {
                if (resource.Type == ResourceType.Stone)
                {
                    this.isGathed = true;
                    return true;
                }
            }

            return false;
        }
    }
}
