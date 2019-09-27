using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        //Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>

        public Engineer(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public List<IRepair> Repairs { get; set; }

        public override string ToString()
        {
            return base.ToString() 
                + $"\nCorps: {this.Corps}\nRepairs:{(this.Repairs.Count == 0 ? "" : "\n")}{string.Join("\n", this.Repairs)}";
        }
    }
}
