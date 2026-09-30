using Microsoft.EntityFrameworkCore;
using RpgApi.Models;

namespace RpgApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {         
    }

    public DbSet<Arma> Armas {get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Arma>().ToTable("TB_ARMAS");

            modelBuilder.Entity<Arma>().HasData(
                new Arma { Id = 1, Nome = "Espada" , Dano = 20},
                new Arma { Id = 2, Nome = "Machado" , Dano = 25},
                new Arma { Id = 3, Nome = "Arco" , Dano = 15},
                new Arma { Id = 4, Nome = "Cajado" , Dano = 12},
                new Arma { Id = 5, Nome = "Adaga" , Dano = 10},
                new Arma { Id = 6, Nome = "Martelo" , Dano = 30},
                new Arma { Id = 7, Nome = "Lança" , Dano = 22}
            );
        }
    }
}