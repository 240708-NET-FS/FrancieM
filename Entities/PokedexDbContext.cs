using Microsoft.EntityFrameworkCore;
using pokedex.Entities;

namespace pokedex.Entities;
public class PokemonDbContext : DbContext
{
    public PokemonDbContext() {}
    public DbSet<Pokemon> Pokemon { get; set; }
    public DbSet<Trainer> Trainers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Replace with your connection string from appsettings.json or elsewhere
            optionsBuilder.UseSqlServer("Server=tcp:fmgm24.database.windows.net,1433;Initial Catalog=fmgm24;Persist Security Info=False;User ID=admin1;Password=CyndaQu1l!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships
        modelBuilder.Entity<Pokemon>()
            .HasKey(p => p.Dexnum);

        modelBuilder.Entity<Trainer>()
            .HasKey(t => t.TrainerID);

        modelBuilder.Entity<Pokemon>()
            .HasOne(p => p.Trainer)
            .WithMany(t => t.Pokemons)
            .HasForeignKey(p => p.TrainerID)
            .OnDelete(DeleteBehavior.Restrict); // Adjust delete behavior as needed
    }
}