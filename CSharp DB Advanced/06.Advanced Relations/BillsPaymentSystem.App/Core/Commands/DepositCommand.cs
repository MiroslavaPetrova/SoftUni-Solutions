using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class DepositCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public DepositCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        //DepositCommand(int userId, decimal amount)
        public string Execute(string[] args)                // here comes string [] args = {"1 amount"};
        {
            StringBuilder sb = new StringBuilder();

            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            User user = context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(pm => pm.CreditCard)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            var bankAccounts = user.PaymentMethods
               .Where(x => x.Type == PaymentType.BankAccount)
               .Select(x => x.BankAccount);

            foreach (var bankAccount in bankAccounts)
            {
                bankAccount.Balance += amount;
                sb.AppendLine($"You have successfully transfered {amount}lv. to your account.");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
