namespace SkillRating.Api.Contracts.Leaderboard;

public sealed record LeaderboardEntryDto(
    Guid PlayerId,
    int Skill,
    int MatchesPlayed,
    string? Name,
    string? ImageUrl);
