﻿using System;

namespace BankAccount
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.Id = 1;
            bankAccount.Balance = 15;

            Console.WriteLine($"Account {bankAccount.Id}, balance {bankAccount.Balance}");
        }
    }
}
