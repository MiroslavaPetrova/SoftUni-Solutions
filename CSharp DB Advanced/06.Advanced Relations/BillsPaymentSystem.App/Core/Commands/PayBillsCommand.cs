using BillsPaymentSystem.App.Core.Commands.Contracts;
using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace BillsPaymentSystem.App.Core.Commands
{
    public class PayBillsCommand : ICommand
    {
        private readonly BillsPaymentSystemContext context;

        public PayBillsCommand(BillsPaymentSystemContext context)
        {
            this.context = context;
        }

        public string Execute(string[] args)
        {
            StringBuilder sb = new StringBuilder();

            //PayBillsCommand(int userId, decimal amount)
            int userId = int.Parse(args[0]);
            decimal amount = decimal.Parse(args[1]);

            User user = context.Users
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.BankAccount)
                .Include(u => u.PaymentMethods)
                .ThenInclude(m => m.CreditCard)
                .FirstOrDefault(u => u.UserId == userId);


            var bankAccounts = user.PaymentMethods
                .Where(x => x.Type == PaymentType.BankAccount)
                .Select(x => x.BankAccount)
                .OrderBy(x => x.BankAccountId)
                .ToArray();

            var creditCards = user.PaymentMethods
                .Where(x => x.Type == PaymentType.CreditCard)
                .Select(x => x.CreditCard)
                .OrderBy(x => x.CreditCardId)
                .ToArray();

            decimal totalAmount = bankAccounts.Sum(ba => ba.Balance) + creditCards.Sum(cc => cc.LimitLeft);

            if (totalAmount < amount)
            {
                sb.AppendLine("Insufficient funds!");
            }
            else 
            {
                sb.AppendLine("You have paid your bills successfully!");
                totalAmount -= amount;
            }

            return sb.ToString().TrimEnd();
        }
    }
}
