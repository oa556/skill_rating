namespace SkillRating.LeaderboardModule.Domain;

public sealed class LeaderboardEntry(
    Guid playerId,
    int skill,
    int matchesPlayed,
    string? name,
    string? imageUrl)
{
    public Guid PlayerId { get; private set; } = playerId;

    public int Skill { get; private set; } = skill;

    public int MatchesPlayed { get; private set; } = matchesPlayed;

    public string? Name { get; private set; } = name;

    public string? ImageUrl { get; private set; } = imageUrl;
}
