using System;
using System.Collections.Generic;
using System.Linq;

namespace MineDraft
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IHarvester> harvesters = new List<IHarvester>();
            //List<Harvester> harvesters = new List<Harvester>();
            //RegisterHarvester Hammer CDD  100 50
            //  RegisterHarvester Sonic AS - 51 100 100 10
            //  RegisterHarvester Sonic { id}
            //{ oreOutput}
            //{ energyRequirement}
            //{ sonicFactor}
            
            string input = Console.ReadLine();

            
            while (input != "END")
            {
                string[] harvesterInfo = input.Split();

                string type = harvesterInfo[1];
                string id = harvesterInfo[2];
                double oreOutput = double.Parse(harvesterInfo[3]);
                double energyRequirement = double.Parse(harvesterInfo[4]);

                if (harvesterInfo.Length == 5)
                {
                    IHarvester harvester = new HammerHarvester(id, oreOutput, energyRequirement);
                    harvesters.Add(harvester);
                }
                else if (harvesterInfo.Length == 6)
                {
                    int sonicFactor = int.Parse(harvesterInfo[5]);

                    IHarvester harvester = new SonicHarvester
                        (id, oreOutput, energyRequirement, sonicFactor);
                    harvesters.Add(harvester);
                }
                input = Console.ReadLine();
            }
            foreach (var harvester in harvesters)
            {
                Console.WriteLine(harvester);
            }
        }
    }
}
