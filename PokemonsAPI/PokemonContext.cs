using Microsoft.EntityFrameworkCore;
using PokemonsAPI.Models;

namespace PokemonsAPI
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options) { }

        public DbSet<Pokemon> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure self-referencing relationships
            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.NextEvolution)
                .WithOne()
                .HasForeignKey<Pokemon>(p => p.NextEvolutionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pokemon>()
                .HasOne(p => p.BaseEvolution)
                .WithMany()
                .HasForeignKey(p => p.BaseEvolutionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}