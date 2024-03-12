using Microsoft.EntityFrameworkCore;
using TrainingApi.Entities;
using TrainingApi.Models;

namespace Training
{
    public class TrainingDbContext : DbContext
    {
        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=Default");
            }
        }
        public DbSet<SalesHeader> SalesHeaders { get; set; }

        public DbSet<SalesDetails> SalesDetails { get; set; }

        public DbSet<SalesDetailsTemp> SalesDetailsTemps { get; set; }
    }
}
