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
    public class ExpenseCategoryConfiguration : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(EntityTypeBuilder<ExpenseCategory> builder)
        {
            // Definir a chave primária
            builder.HasKey(ec => ec.Id);

            // Configurar a propriedade 'Name'
            builder.Property(ec => ec.Name)
                .IsRequired()
                .HasMaxLength(100);

            // Configurar a propriedade 'Description' (se existir)
            builder.Property(ec => ec.Description)
                .HasMaxLength(255);
        }
    }
}
