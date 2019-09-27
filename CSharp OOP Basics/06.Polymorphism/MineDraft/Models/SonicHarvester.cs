
public class SonicHarvester : Harvester
    {
        private int sonicFactor;

        public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor)
          : base(id, oreOutput, energyRequirement)
        {
            this.SonicFactor = sonicFactor;
            this.EnergyRequirement /= sonicFactor;
        }

        //TODO validations
        public int SonicFactor
        {
            get => sonicFactor;
            set
            {
                sonicFactor = value;
            }
        }

        public override string ToString()
        {
            return $"Successfully registered Sonic Harvester - {this.Id}";
        }
    }

