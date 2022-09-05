using Microsoft.EntityFrameworkCore;
using QuizGame.Models;

namespace QuizGame.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
    {
    }
    
    public DbSet<Game> Games { get; set; }
    public DbSet<Player> Players { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Game>()
            .HasMany(g => g.Players)
            .WithOne(p => p.Game)
            .HasForeignKey(p => p.GameId);

        modelBuilder.Entity<Player>()
            .HasOne(p => p.Game)
            .WithMany(g => g.Players)
            .HasForeignKey(p => p.GameId);
    }
}