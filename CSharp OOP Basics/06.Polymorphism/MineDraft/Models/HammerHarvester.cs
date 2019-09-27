
public class HammerHarvester : Harvester
{
    //private const double oreIncrease = 2 * this.OreOutput;

    public HammerHarvester(string id, double oreOutput, double energyRequirement)
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += 2 * oreOutput;   // TODO make them private const doubles
        this.EnergyRequirement += energyRequirement; // can br done in bes ctor / 2
    }

    public override string ToString()
    {
        return $"Successfully registered Hammer Harvester - {this.Id}";
    }
}


