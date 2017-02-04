using System;

namespace AcademyRPG
{
    public class Rock : WorldObject, IResource
    {
        public Rock(int hitPoints, Point position) 
            : base(position)
        {
            this.HitPoints = hitPoints;
        }

        public int Quantity
        {
            get
            {
                return this.HitPoints / 2;
            }
        }

        public ResourceType Type
        {
            get
            {
                return ResourceType.Stone;
            }
        }
    }
}
