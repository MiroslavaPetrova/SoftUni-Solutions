using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class BankAccount
    {
        private int id;
        private decimal balance;
        public BankAccount()
        {

        }
        public BankAccount(int id, decimal balance)
        {
            this.Id = id;
            this.Balance = balance;
        }

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value > 0)
                {
                    throw new Exception("Too big number!");
                }
                this.id = value;
            }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }
        }
    }
}
