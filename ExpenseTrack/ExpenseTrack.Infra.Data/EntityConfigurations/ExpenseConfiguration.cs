using ExpenseTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Infra.Data.EntityConfigurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            // Definir a chave primária
            builder.HasKey(e => e.Id);

            // Configurar as propriedades
            builder.Property(e => e.Description)
                .IsRequired();

            builder.Property(e => e.Status)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.CreatedAt)
                .IsRequired();

            builder.Property(e => e.UpdatedAt)
                .IsRequired();

            // Configurar relação com User (UserId)
            builder.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            // Configurar relação com ExpenseCategory
            builder.HasOne(e => e.ExpenseCategory)
                .WithMany()
                .HasForeignKey(e => e.ExpenseCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relação com Currency
            builder.HasOne(e => e.Currency)
                .WithMany()
                .HasForeignKey(e => e.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relação com ExchangeRate
            builder.HasOne(e => e.ExchangeRate)
                .WithMany()
                .HasForeignKey(e => e.ExchangeRateId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configurar relação com Receipt
            builder.HasOne(e => e.Receipt)
                .WithMany(r => r.Expenses)
                .HasForeignKey(e => e.ReceiptId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
