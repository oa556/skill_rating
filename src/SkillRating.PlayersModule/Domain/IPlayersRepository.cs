namespace SkillRating.PlayersModule.Domain;

public interface IPlayersRepository
{
    Task AddAsync(Player player);

    Task<Player?> GetByIdAsync(Guid id);

    Task<Player[]> ListAsync(
        Guid id,
        CancellationToken cancellationToken = default);

    Task<Player[]> ListAsync(
        Guid[] ids,
        CancellationToken cancellationToken = default);

    Task SaveChangesAsync();
}
