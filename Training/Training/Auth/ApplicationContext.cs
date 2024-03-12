using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApi.Models;

namespace TrainingApi.ApplicationUser
{
    public class ApplicationContext: IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options) 
        { 

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Default");
            }
        }
    }
}
