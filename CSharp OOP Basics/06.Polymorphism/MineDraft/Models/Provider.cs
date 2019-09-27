using System;

public abstract class Provider : IProvider
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
            {
                throw new ArgumentException
                    ("Provider is not registered, because of it's EnergyOutput");
            }
            energyOutput = value;
        }
    }
}

