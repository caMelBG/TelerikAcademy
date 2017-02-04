using System;
using System.Collections.Generic;
using System.Linq;

namespace AcademyRPG
{
    public class Ninja : Character, IFighter, IDestroyable, IGatherer

    {
        public Ninja(string name, Point position, int owner) 
            : base(name, position, owner)
        {
            this.AttackPoints = 0;
            this.HitPoints = 1;
        }

        public bool IsDestroyed
        {
            get
            {
                return false;
            }
        }

        public int AttackPoints { get; private set; }

        public int DefensePoints { get; private set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var target = availableTargets.OrderBy(x => x.HitPoints)
                .First(x => x.Owner != 0 && x.Owner != this.Owner);

            return availableTargets.IndexOf(target);
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}