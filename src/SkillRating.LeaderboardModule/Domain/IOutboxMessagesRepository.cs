namespace SkillRating.LeaderboardModule.Domain;

public interface IOutboxMessagesRepository
{
    Task QueueInOutboxAsync(OutboxMessage message);

    Task<OutboxMessage[]> ListAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync();
}
