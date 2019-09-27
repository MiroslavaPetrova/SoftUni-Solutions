using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        private string name; 
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.Name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        public string Name { get; set; } 

        public List<Person> FirstTeam
        {
            get { return firstTeam; }
        }

        public List<Person> ReserveTeam
        {
            get { return reserveTeam; }
        }

        public void AddPlayer(Person player)
        {
            if (player.Age < 40)
            {
                firstTeam.Add(player);
            }
            else
            {
                reserveTeam.Add(player);
            }
        }
    }
}

