using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class UserInfoCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public UserInfoCommand(BillsPaymentSystemContext context )
        {
            this.context = context;
        }

        public string Execute(string[] args)   // here comes string [] args = {"1"};
        {
            StringBuilder sb = new StringBuilder();

            int userId = int.Parse(args[0]);

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
                .Where(pm => pm.Type == PaymentType.BankAccount)
                .Select(pm => pm.BankAccount);          

            var creditCards = user.PaymentMethods
                .Where(pm => pm.Type == PaymentType.CreditCard)
                .Select(x => x.CreditCard);            

            sb.AppendLine($"User: {user.FirstName} {user.LastName}");

            sb.AppendLine("Bank Accounts:");
            foreach (var bankAccount in bankAccounts)
            {
                sb.AppendLine($"--- ID: {bankAccount.BankAccountId}");
                sb.AppendLine($"--- Balance: {bankAccount.Balance}");
                sb.AppendLine($"--- Bank: {bankAccount.BankName}");
                sb.AppendLine($"--- SWIFT: {bankAccount.SwiftCode}");
            }

            sb.AppendLine("Credit Cards:");
            foreach (var creditCard in creditCards)
            {
                sb.AppendLine($"--- ID: {creditCard.CreditCardId}");
                sb.AppendLine($"--- Limit: {creditCard.Limit}");
                sb.AppendLine($"--- Money Owed: {creditCard.MoneyOwed}");
                sb.AppendLine($"--- Limit Left: {creditCard.LimitLeft}");
                sb.AppendLine($"--- Expiration Date: {creditCard.ExpirationDate.ToString("yyyy/MM", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
