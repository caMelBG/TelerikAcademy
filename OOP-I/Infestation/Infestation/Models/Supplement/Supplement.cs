namespace Infestation
{
    public abstract class Supplement : ISupplement
    {
        public Supplement(int aggressionEffect, int healthEffect, int powerEffect)
        {
            this.AggressionEffect = aggressionEffect;
            this.HealthEffect = healthEffect;
            this.PowerEffect = powerEffect;
        }

        public int AggressionEffect { get; private set; }
        public int HealthEffect { get; private set; }
        public int PowerEffect { get; private set; }

        public void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
