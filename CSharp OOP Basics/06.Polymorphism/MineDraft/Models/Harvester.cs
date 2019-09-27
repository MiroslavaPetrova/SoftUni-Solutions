using System;

public abstract class Harvester : IHarvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }
    //TODO add validations for oreoutput & energy req = DONE!
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException
                    ("Harvester is not registered, because of it's OreOutput"); 
            }
            oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException
                    ("Harvester is not registered, because of it's EnergyRequirement"); 
            }
            energyRequirement = value;
        }
    }
    // TODO try to add tyoe into ctor & override on
}

