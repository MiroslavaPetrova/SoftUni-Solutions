using System;

namespace Mankind
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            try
            {
                string[] studentInfo = Console.ReadLine().Trim()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries); 
                string firstName = studentInfo[0];
                string lastName = studentInfo[1];
                string facultyNumber = studentInfo[2];

                Student student = new Student(firstName, lastName, facultyNumber);

                string[] workerInfo = Console.ReadLine().Trim()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string firstNameWorker = workerInfo[0];
                string lastNameWorker = workerInfo[1];
                decimal salary = decimal.Parse(workerInfo[2]);
                double workingHours = double.Parse(workerInfo[3]);

                Worker worker = new Worker(firstNameWorker, lastNameWorker, salary, workingHours);

                Console.WriteLine();
                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
