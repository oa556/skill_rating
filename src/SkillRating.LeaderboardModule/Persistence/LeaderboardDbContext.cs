using Microsoft.EntityFrameworkCore;
using SkillRating.LeaderboardModule.Domain;

namespace SkillRating.LeaderboardModule.Persistence;

internal sealed class LeaderboardDbContext(DbContextOptions<LeaderboardDbContext> options)
    : DbContext(options)
{
    public DbSet<OutboxMessage> OutboxMessages { get; private set; }

    public DbSet<LeaderboardEntry> Leaderboard { get; private set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("LeaderboardModule");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ILeaderboardModule).Assembly);
    }
}
