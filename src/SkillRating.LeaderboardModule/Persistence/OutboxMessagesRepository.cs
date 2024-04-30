using Microsoft.EntityFrameworkCore;
using SkillRating.LeaderboardModule.Domain;

namespace SkillRating.LeaderboardModule.Persistence;

internal sealed class OutboxMessagesRepository(LeaderboardDbContext dbContext)
    : IOutboxMessagesRepository
{
    public async Task QueueInOutboxAsync(OutboxMessage message)
    {
        await dbContext.OutboxMessages.AddAsync(message);
    }

    public async Task<OutboxMessage[]> ListAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.OutboxMessages
            .Where(om => om.ProcessedOnUtc == null)
            .OrderBy(om => om.OccurredOnUtc)
            .ToArrayAsync(cancellationToken);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
