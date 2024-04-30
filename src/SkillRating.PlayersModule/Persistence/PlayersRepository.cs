using Microsoft.EntityFrameworkCore;
using SkillRating.PlayersModule.Domain;

namespace SkillRating.PlayersModule.Persistence;

internal sealed class PlayersRepository(PlayersDbContext dbContext)
    : IPlayersRepository
{
    public async Task AddAsync(Player player)
    {
        await dbContext.Players.AddAsync(player);
    }

    public async Task<Player?> GetByIdAsync(Guid id)
    {
        return await dbContext.Players.FindAsync(id);
    }

    public async Task<Player[]> ListAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Players
            .Where(p => p.Id != id)
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Player[]> ListAsync(
        Guid[] ids,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Players
            .Where(p => ids.Contains(p.Id))
            .AsNoTracking()
            .ToArrayAsync(cancellationToken);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
