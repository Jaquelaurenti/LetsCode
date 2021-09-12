using StarWarsResistence.Models;
using StarWarsResistence.Models.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Utils; 
namespace StarWarsResistence.Models
{
    public class CentralErroContexto : DbContext
    {
        public DbSet<Rebelde> Rebeldes { get; set; }

        public CentralErroContexto(DbContextOptions<CentralErroContexto> options) : base(options)
        {

        }

        public CentralErroContexto()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase(databaseName: "StarWarsResistence");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RebeldeConfiguration());
        }
    }
}