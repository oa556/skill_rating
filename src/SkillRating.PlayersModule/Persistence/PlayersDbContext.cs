using Microsoft.EntityFrameworkCore;
using SkillRating.PlayersModule.Domain;

namespace SkillRating.PlayersModule.Persistence;

internal sealed class PlayersDbContext(DbContextOptions<PlayersDbContext> options)
    : DbContext(options)
{
    public DbSet<Player> Players { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("PlayersModule");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IPlayersModule).Assembly);
    }
}
