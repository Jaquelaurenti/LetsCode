using StarWarsResistence.Models;
using StarWarsResistence.Models.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using StarWarsResistence.Utils; 
namespace StarWarsResistence.Models
{
    public class StarWarsContexto : DbContext
    {
        public DbSet<Rebelde> Rebeldes { get; set; }
        public DbSet<Localizacao> Localizacao { get; set; }
        public DbSet<Inventario> Inventario { get; set; }
        public DbSet<ItemInventario> ItemInventario { get; set; }

        public StarWarsContexto(DbContextOptions<StarWarsContexto> options) : base(options)
        {

        }

        public StarWarsContexto()
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
            modelBuilder.ApplyConfiguration(new LocalizacaoConfiguration());
            modelBuilder.ApplyConfiguration(new InventarioConfiguration());
            modelBuilder.ApplyConfiguration(new ItemInventarioConfiguration());
        }
    }
}