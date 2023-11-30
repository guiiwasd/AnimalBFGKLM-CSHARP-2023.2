using AnimalBFGKLM.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimalBFGKLM.Data
{
    public class AnimalContext : DbContext
    {
        public AnimalContext(DbContextOptions<AnimalContext> options) : base(options) { }

        public DbSet<AnimalTipo> AnimalTipos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AnimalTipo>().HasKey(a => a.AnimalId);
        }
    }
}
