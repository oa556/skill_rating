namespace SkillRating.LeaderboardModule.Domain;

public interface ILeaderboardRepository
{
    Task UpdateLeaderboardAsync(LeaderboardEntry[] entries);

    Task<LeaderboardEntry[]> ListAsync(CancellationToken cancellationToken = default);
}
