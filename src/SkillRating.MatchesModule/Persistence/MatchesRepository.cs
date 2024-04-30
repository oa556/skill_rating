using Microsoft.EntityFrameworkCore;
using SkillRating.MatchesModule.Domain;

namespace SkillRating.MatchesModule.Persistence;

internal sealed class MatchesRepository(MatchesDbContext dbContext)
    : IMatchesRepository
{
    public async Task AddAsync(Match match)
    {
        await dbContext.AddAsync(match);
    }

    public async Task<Match[]> ListAsync(
        Guid playerId,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Matches
            .Include(m => m.Participants)
            .Where(m => m.Participants.Any(p => p.PlayerId == playerId))
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Match[]> ListAsync(CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Matches
            .Include(m => m.Participants)
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
