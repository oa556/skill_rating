using SkillRating.Api.Contracts.Players;

namespace SkillRating.PlayersModule.Domain;

public interface IPlayersRepository
{
    Task AddAsync(Player player);

    Task<Player?> GetByIdAsync(Guid id);

    Task<PlayerDto[]> ListAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Dictionary<Guid, PlayerDto>> ListAsync(
        Guid[] ids,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync();
}
