using ExpenseTrack.Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrack.Infra.Data.Seeders
{
    public static class RolesSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>());

            if (context.Roles.Any()) 
            { 
                return;
            }

            context.Roles.AddRange(
                new IdentityRole("Administrador"),
                new IdentityRole("Gerente"),
                new IdentityRole("Funcionário")
            );

            context.SaveChanges();
        }
    }
}
