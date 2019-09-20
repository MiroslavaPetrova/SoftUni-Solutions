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
    public class WithdrawCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public WithdrawCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            //Withdraw(int userId, decimal amount)

            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            User user = context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.CreditCard)
                .FirstOrDefault(u => u.UserId == userId);

            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} not found!");
            }

            var creditCards = user.PaymentMethods
                .Where(x => x.Type == PaymentType.CreditCard)
                .Select(x => x.CreditCard)
                .OrderBy(x => x.CreditCardId);

            foreach (var creditCard in creditCards)
            {
                if (creditCard.LimitLeft < amount)
                {
                    sb.AppendLine("The requested amount excedes your funds!");
                }
                creditCard.Limit -= amount;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
