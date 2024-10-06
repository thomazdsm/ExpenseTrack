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
    public class ApprovalConfiguration : IEntityTypeConfiguration<Approval>
    {
        public void Configure(EntityTypeBuilder<Approval> builder)
        {
            // Definir a chave primária
            builder.HasKey(a => a.Id);

            // Configurar propriedades
            builder.Property(a => a.Action)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(a => a.Comments)
                   .HasMaxLength(500);

            builder.Property(a => a.ApprovedAt)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            // Configurar relacionamento com Expense
            builder.HasOne(a => a.Expense)
                   .WithMany()
                   .HasForeignKey(a => a.ExpenseId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Configurar relacionamento com Manager (User)
            builder.HasOne(a => a.Manager)
                   .WithMany()
                   .HasForeignKey(a => a.ManagerId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
