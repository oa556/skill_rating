namespace SkillRating.App.Models;

public sealed class LeaderboardEntry(
    Guid playerId,
    int skill,
    int matchesPlayed,
    string? name,
    string? imageUrl)
{
    public Guid PlayerId { get; set; } = playerId;

    public int Skill { get; set; } = skill;

    public int MatchesPlayed { get; set; } = matchesPlayed;

    public string? Name { get; set; } = name;

    public string? ImageUrl { get; set; } = imageUrl;

    public string MatchesPlayedText => MatchesPlayed == 1 ? "1 match played" : $"{MatchesPlayed} matches played";
}
