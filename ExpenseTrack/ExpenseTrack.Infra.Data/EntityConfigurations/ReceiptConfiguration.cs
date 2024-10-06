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
    public class ReceiptConfiguration : IEntityTypeConfiguration<Receipt>
    {
        public void Configure(EntityTypeBuilder<Receipt> builder)
        {
            // Definir a chave primária
            builder.HasKey(r => r.Id);

            // Configurar as propriedades
            builder.Property(r => r.FilePath)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.UploadedAt)
                .IsRequired();

            // Configurar relação com User (UploadedBy)
            builder.HasOne(r => r.UploadedByUser)
                .WithMany()
                .HasForeignKey(r => r.UploadedBy)
                .OnDelete(DeleteBehavior.Cascade);

            // Relação opcional com Expenses (se aplicável)
            builder.HasMany(r => r.Expenses)
                .WithOne(e => e.Receipt)
                .HasForeignKey(e => e.ReceiptId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
