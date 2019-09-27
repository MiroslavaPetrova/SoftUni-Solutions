using System;
using System.Collections.Generic;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private double dailyWorkingHours; 

        public Worker(string firstName, string lastName, decimal weekSalary, double dailyWorkingHours)
            :base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.DailyWorkingHours = dailyWorkingHours;
        }

        public decimal WeekSalary
        {
            get => weekSalary;
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                weekSalary = value;
            }
        }
        public double DailyWorkingHours
        {
            get => dailyWorkingHours;
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                dailyWorkingHours = value;
            }
        }
        public decimal MoneyPerHour
        {
            get => this.CalculateMoneyPerHour();
        }

        private decimal CalculateMoneyPerHour()
        {
            return this.WeekSalary / 5 / (decimal)this.DailyWorkingHours;
        }

        public override string ToString()
        {
            return  $"First Name: {this.FirstName}{Environment.NewLine}" +
                    $"Last Name: {this.LastName}{Environment.NewLine}" +
                    $"Week Salary: {this.WeekSalary:f2}{Environment.NewLine}" +
                    $"Hours per day: {this.DailyWorkingHours:f2}{Environment.NewLine}" +
                    $"Salary per hour: {this.MoneyPerHour:f2}";
        }

        // a method weekSalary / 5 /dailyWHourscalcmoney per\hour
        //todo : override toString()
        // TRIM() ??????
    }
}
