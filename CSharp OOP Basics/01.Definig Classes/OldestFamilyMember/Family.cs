using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OldestFamilyMember
{
    public class Family
    {
        private List<Person> people;

        public List<Person> People
        {
            get { return this.people; }
            set { this.people = value; }
        }

        public Family()
        {
            people = new List<Person>();  
        }
        public void AddMember(Person member)
        {
            if (member == null)
            {
                throw new Exception();
            }
            people.Add(member);
        }
        public Person GetOldestPerson()
        {
            return People.OrderByDescending(a => a.Age).FirstOrDefault();
                                         //firstOrDefault returns OBJECT
        }
    }
}
