using BillsPaymentSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BillsPaymentSystem.Data.EntityConfiguration
{
    public class PaymentMethodConfig : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.HasOne(c => c.CreditCard)
                .WithOne(c => c.PaymentMethod);

            builder.HasOne(b => b.BankAccount)
                .WithOne(b => b.PaymentMethods);
        }
    }
}
