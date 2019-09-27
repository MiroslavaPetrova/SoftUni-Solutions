using MilitaryElite.Contracts;

namespace MilitaryElite.Models
{
    public class Private : Soldier, IPrivate
    {
        private int id;
        private string firstName;
        private string lastName;
        private decimal salary;

        //Private 1 Pesho Peshev 22.22

        public Private(int id, string firstName, string lastName, decimal salary) 
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }

        public decimal Salary { get; private set; }

        public override string ToString()
        {
            return base.ToString() + $"Salary: {this.Salary:F2}";
        }
    }
}
