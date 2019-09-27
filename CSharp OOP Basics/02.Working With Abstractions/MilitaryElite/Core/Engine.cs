using MilitaryElite.Contracts;
using MilitaryElite.Enums;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MilitaryElite.Core
{
    public class Engine
    {
        private ICollection<ISoldier> soldiers;
        private ISoldier soldier;

        public Engine()
        {
            this.soldiers = new List<ISoldier>();
        }

        public void Run()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] args = input.Split();

                // Private <id> <firstName> <lastName> <salary>”
                // LieutenantGeneral <id> <firstName> <lastName> <salary> <private1Id> <private2Id> … <privateNId>
                // Engineer <id> <firstName> <lastName> <salary> <corps> <repair1Part> <repair1Hours> … <repairNPart> <repairNHours>” 
                //Commando <id> <firstName> <lastName> <salary> <corps> <mission1CodeName>  <mission1state> … <missionNCodeName> <missionNstate>
                //Spy <id> <firstName> <lastName> <codeNumber>”

                string type = args[0];
                int id = int.Parse(args[1]);
                string firstName = args[2];
                string lastName = args[3];

                if (type == "Private")
                {
                    decimal salary = decimal.Parse(args[4]);
                    soldier = GetPrivateSoldier(id, firstName, lastName, salary);
                }
                else if(type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(args[4]);
                    soldier = GetLieutenantGeneral(id, firstName, lastName, salary, args);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(args[4]);
                    soldier = GetEngineer(id, firstName, lastName, salary, args);
                }
                else if(type == "Commando")
                {
                    decimal salary = decimal.Parse(args[4]);
                    soldier = GetCommando(id, firstName, lastName, salary, args);
                    
                }
                else if(type == "Spy")
                {
                    soldier = GetSpySoldier(id, firstName, lastName, args);
                }
                
                if (soldier != null)
                {
                    this.soldiers.Add(soldier);
                }

                input = Console.ReadLine();
            }
            foreach (var soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private ISoldier GetSpySoldier(int id, string firstName, string lastName, string[] args)
        {
            int codeNumber = int.Parse(args[4]);

            ISpy spy = new Spy(id, firstName, lastName, codeNumber);
            return spy;
        }

        private ISoldier GetCommando(int id, string firstName, string lastName, decimal salary, string[] args)
        {
            //. In case of invalid corps the entire line should be skipped, 
            //in case of an invalid mission state only the mission should be skipped. 

            var isValidCorps = Enum.TryParse(args[5], out Corps corps);

            if (!isValidCorps)
            {
                return null;
            }
            ICommando commando = new Commando(id, firstName, lastName, salary, corps);

            for (int i = 6; i < args.Length; i += 2)
            {
                string codeName = args[i];
                string missionState = args[i + 1];

                var isValidState = Enum.TryParse(missionState, out State state);

                if (!isValidState)
                {
                    continue;
                }

                IMission mission = new Mission(codeName, state);

                commando.Missions.Add(mission);
            }
            return commando;
        }

        private ISoldier GetEngineer(int id, string firstName, string lastName, decimal salary, string[] args)
        {
            //In case of invalid corps the entire line should be skipped 
            
            var isValidCorps = Enum.TryParse(args[5], out Corps corps);

            if (!isValidCorps)
            {
                return null;
            }
            IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

            for (int i = 6; i < args.Length; i += 2)  
            {
                string partName = args[i];
                int hours = int.Parse(args[i + 1]);
                IRepair repair = new Repair(partName, hours);
                engineer.Repairs.Add(repair);
            }

            return engineer;
        }

        private ISoldier GetLieutenantGeneral(int id, string firstName, string lastName, decimal salary, string[] args)
        {
            ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            for (int i = 5; i < args.Length; i++)
            {
                int targetId = int.Parse(args[i]);

                IPrivate privateSoldier = (IPrivate)this.soldiers.FirstOrDefault(p => p.Id == targetId);

                lieutenantGeneral.Privates.Add(privateSoldier);
            }

            return lieutenantGeneral;
        }

        private ISoldier GetPrivateSoldier(int id, string firstName, string lastName, decimal salary)
        {
            IPrivate privateSoldier = new Private(id, firstName, lastName, salary);

            return privateSoldier;
        }
    }
}
