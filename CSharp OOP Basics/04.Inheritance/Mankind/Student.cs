using System;
using System.Collections.Generic;
using System.Linq;

namespace Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get => facultyNumber;
            set
            {
                if (value.Length <= 4 || value.Length > 10) 
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                for (int i = 0; i < value.Length; i++)
                {
                    if (!Char.IsLetterOrDigit(value[i]))
                    {
                        throw new ArgumentException("Invalid faculty number!");
                    }
                }
                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return  $"First Name: {this.FirstName}{Environment.NewLine}" +
                    $"Last Name: {this.LastName}{Environment.NewLine}" +
                    $"Faculty number: {this.facultyNumber}";
        }
    }
}
