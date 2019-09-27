using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite.Models
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        //Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>” 

        public Commando(int id, string firstName, string lastName, decimal salary, Corps corps)
            : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public List<IMission> Missions { get; set; }
        // Name: Penka Ivanova Id: 19 Salary: 150.15
        // Corps: Airforces
        // Missions:
        // Code Name: Freedom State: inProgress


        public override string ToString()
        {
            return base.ToString() 
                + $"\nCorps: {this.Corps}\nMissions:{(this.Missions.Count == 0 ? "" : "\n")}{string.Join("\n", this.Missions)}";
        }
    }
}
