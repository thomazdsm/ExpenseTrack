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
    public class ExchangeRateConfiguration : IEntityTypeConfiguration<ExchangeRate>
    {
        public void Configure(EntityTypeBuilder<ExchangeRate> builder)
        {
            builder.HasKey(er => er.Id);

            builder.Property(er => er.Rate)
                .IsRequired()
                .HasColumnType("decimal(18,6)");

            builder.Property(er => er.EffectiveDate)
                .IsRequired();

            builder.HasOne(er => er.BaseCurrency)
                .WithMany(c => c.ExchangeRatesBase)
                .HasForeignKey(er => er.BaseCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(er => er.TargetCurrency)
                .WithMany(c => c.ExchangeRatesTarget)
                .HasForeignKey(er => er.TargetCurrencyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
