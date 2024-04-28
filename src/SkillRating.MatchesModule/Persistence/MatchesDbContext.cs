using Microsoft.EntityFrameworkCore;
using SkillRating.MatchesModule.Domain;
using SkillRating.SharedKernel.Events;

namespace SkillRating.MatchesModule.Persistence;

internal sealed class MatchesDbContext(
    DbContextOptions<MatchesDbContext> options,
    IDomainEventPublisher publisher)
    : DbContext(options)
{
    public DbSet<Match> Matches { get; private set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("MatchesModule");

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IMatchesModule).Assembly);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var result = await base.SaveChangesAsync(cancellationToken);

        var entitiesWithEvents = ChangeTracker.Entries<Entity>()
            .Select(e => e.Entity)
            .Where(e => e.HasDomainEvents())
            .ToArray();
        await publisher.PublishAndClearEvents(entitiesWithEvents);

        return result;
    }
}
