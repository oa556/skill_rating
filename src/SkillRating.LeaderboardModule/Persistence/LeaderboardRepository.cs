using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using SkillRating.LeaderboardModule.Domain;

namespace SkillRating.LeaderboardModule.Persistence;

internal sealed class LeaderboardRepository(LeaderboardDbContext dbContext)
    : ILeaderboardRepository
{
    public async Task UpdateLeaderboardAsync(LeaderboardEntry[] entries)
    {
        await dbContext.BulkInsertOrUpdateOrDeleteAsync(entries);
    }

    public async Task<LeaderboardEntry[]> ListAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext.Leaderboard
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);
    }
}
