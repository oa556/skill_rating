using Microsoft.EntityFrameworkCore;
using SkillRating.Api.Contracts.Players;
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

    public async Task<PlayerDto[]> ListAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Players
            .Where(p => p.Id != id)
            .Select(p => new PlayerDto(p.Id, p.Name, p.ImageUrl))
            .ToArrayAsync(cancellationToken);
    }

    public async Task<Dictionary<Guid, PlayerDto>> ListAsync(
        Guid[] ids,
        CancellationToken cancellationToken = default)
    {
        return await dbContext
            .Players
            .Where(p => ids.Contains(p.Id))
            .Select(p => new PlayerDto(p.Id, p.Name, p.ImageUrl))
            .ToDictionaryAsync(p => p.Id, cancellationToken);
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
