using MilitaryElite.Contracts;
using System.Collections.Generic;

namespace MilitaryElite.Models
{
    public class LieutenantGeneral : Private, ILieutenantGeneral
    {
        //LieutenantGeneral 3 Joro Jorev 105.35 222 1

        public LieutenantGeneral(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public List<IPrivate> Privates { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"\nPrivates:\n  {string.Join("\n  ", this.Privates)}";
        }
    }
}
