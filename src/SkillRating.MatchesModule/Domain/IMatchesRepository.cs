namespace SkillRating.MatchesModule.Domain;

public interface IMatchesRepository
{
    Task AddAsync(Match match);

    Task<Match[]> ListAsync(
        Guid playerId,
        CancellationToken cancellationToken = default);

    Task<Match[]> ListAsync(CancellationToken cancellationToken = default);

    Task SaveChangesAsync();
}
