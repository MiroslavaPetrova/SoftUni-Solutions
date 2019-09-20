using BillsPaymentSystem.Data;
using BillsPaymentSystem.Models;
using BillsPaymentSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BillsPaymentSystem.App
{
    public class DbInitializer
    {
        public static void Seed(BillsPaymentSystemContext context)
        {
            SeedUsers(context);
            SeedCreditCards(context);
            SeedBankAccounts(context);
            SeedPaymentMethods(context);
        }

        private static void SeedPaymentMethods(BillsPaymentSystemContext context)
        {
            List<PaymentMethod> paymentMethods = new List<PaymentMethod>();

            for (int i = 0; i < 5; i++)
            {
                var paymentMethod = new PaymentMethod()
                {
                    UserId = new Random().Next(1, 6),
                    Type = (PaymentType)new Random().Next(0, 2),
                };

                if (i % 3 == 0)
                {

                    paymentMethod.CreditCardId = new Random().Next(1,6);
                    paymentMethod.BankAccountId = new Random().Next(1, 6);
                }
                else if (i % 2 == 0)
                {
                    paymentMethod.CreditCardId = new Random().Next(1, 6);
                }
                else
                {
                    paymentMethod.BankAccountId = new Random().Next(1, 6);
                }

                if (!IsValid(paymentMethod))
                {
                    continue;
                }
                paymentMethods.Add(paymentMethod);
            }
            context.PaymentMethods.AddRange(paymentMethods);
            context.SaveChanges();
        }
        
        private static void SeedBankAccounts(BillsPaymentSystemContext context)
        {
            List<BankAccount> bankAccounts = new List<BankAccount>();

            for (int i = 0; i < 5; i++)
            {
                var bankAccount = new BankAccount()
                {
                    Balance = new Random().Next(1, 5000),
                    BankName = "Bank" + i,
                    SwiftCode = "Swift" + i + 1
                };

                if (!IsValid(bankAccount))
                {
                    continue;
                }
                bankAccounts.Add(bankAccount);
            }

            context.BankAccounts.AddRange(bankAccounts);
            context.SaveChanges();
        }

        private static void SeedCreditCards(BillsPaymentSystemContext context)
        {
            List<CreditCard> creditCards = new List<CreditCard>();

            for (int i = 0; i < 5; i++)
            {
                var creditCard = new CreditCard()
                {
                    Limit = new Random().Next(1, 50),
                    MoneyOwed = new Random().Next(1, 50),
                    ExpirationDate = DateTime.Now.AddDays(new Random().Next(1,20)),
                };

                if (!IsValid(creditCard))
                {
                    continue;
                }
                creditCards.Add(creditCard);
            }
            context.CreditCards.AddRange(creditCards);
            context.SaveChanges();
        }

        private static void SeedUsers(BillsPaymentSystemContext context)
        {
            string[] firstNames = { "Petar", "Ivan", "Marin", "Dimo", "Veselin" };

            string[] lastNames = { "Jivkov", "Lechev", "Dimitrov", "Lilov", "Petrov" };

            string[] emails = { "petrov@mail.bg", "ivanov@abv.bg","dm@yahoo.com", "j@abv.bg","mn@yahoo.com" };

            string[] passwords = {"ne2", "7383tr", "45", "op0", "jehyru7"};

            List<User> users = new List<User>();

            for (int i = 0; i < firstNames.Length; i++)
            {
                var user = new User()
                {
                    FirstName = firstNames[i],
                    LastName = lastNames[i],
                    Email = emails[i],
                    Password = passwords[i]
                };

                if(!IsValid(user))
                {
                    continue;
                }

                users.Add(user);
            }

            context.Users.AddRange(users);
            context.SaveChanges();
        }

        private static bool IsValid(object entity)
        {
            ValidationContext validationContext = new ValidationContext(entity);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(entity, validationContext, validationResults, true);

            return isValid;
        }
    }
}
