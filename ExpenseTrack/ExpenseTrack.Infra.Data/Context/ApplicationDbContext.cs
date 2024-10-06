using ExpenseTrack.Domain.Entities;
using ExpenseTrack.Infra.Data.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrack.Infra.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }
        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Receipt> Receipts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configurações de Currency
            builder.ApplyConfiguration(new CurrencyConfiguration());

            // Configurações de ExchangeRate
            builder.ApplyConfiguration(new ExchangeRateConfiguration());

            // Configurações de ExpenseCategory
            builder.ApplyConfiguration(new ExpenseCategoryConfiguration());

            // Configurações de Expense
            builder.ApplyConfiguration(new ExpenseConfiguration());

            // Configurações de Receipt
            builder.ApplyConfiguration(new ReceiptConfiguration());
        }
    }
}
