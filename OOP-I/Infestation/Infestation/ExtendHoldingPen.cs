namespace Infestation
{
    public class ExtendHoldingPen : HoldingPen
    {
        protected override void ExecuteInsertUnitCommand(string[] commandWords)
        {
            var unitType = commandWords[1];
            var unitId = commandWords[2];
            Unit unit;
            switch (unitType)
            {
                case "Marine": unit = new Marine(unitId);
                    unit.AddSupplement(new WeaponrySkill());
                    base.InsertUnit(unit);
                    break;
                case "Queen":
                    unit = new Queen(unitId);
                    base.InsertUnit(unit);
                    break;
                case "Parasite":
                    unit = new Parasite(unitId);
                    base.InsertUnit(unit);
                    break;
                case "Tank":
                    unit = new Tank(unitId);
                    base.InsertUnit(unit);
                    break;
                default: base.ExecuteInsertUnitCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteAddSupplementCommand(string[] commandWords)
        {
            var supplementType = commandWords[1];
            var unitId = commandWords[2];
            var unit = base.GetUnit(unitId);
            switch (supplementType)
            {
                case "PowerCatalyst":
                    var powerCatalyst = new PowerCatalyst();
                    unit.AddSupplement(powerCatalyst);
                    break;
                case "HealthCatalyst":
                    var healthCatalyst = new HealthCatalyst();
                    unit.AddSupplement(healthCatalyst);
                    break;
                case "AggressionCatalyst":
                    var aggressionCatalyst = new AggressionCatalyst();
                    unit.AddSupplement(aggressionCatalyst);
                    break;
                case "Weapon":
                    var weapon = new Weapon();
                    if (unit is Marine)
                    {
                        unit.AddSupplement(weapon);
                    }
                    break;
                default: throw new System.NotImplementedException("Not implemented supplement!");
            }
        }
    }
}
