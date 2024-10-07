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
    public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
    {
        public void Configure(EntityTypeBuilder<AuditLog> builder)
        {
            // Definir a chave primária
            builder.HasKey(al => al.Id);

            // Configurar propriedades
            builder.Property(al => al.Action)
                   .IsRequired()
                   .HasMaxLength(255);

            builder.Property(al => al.Entity)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(al => al.EntityId)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(al => al.Timestamp)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            // Configurar relacionamento com User
            builder.HasOne(al => al.User)
                   .WithMany()
                   .HasForeignKey(al => al.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
