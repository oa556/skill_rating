namespace SkillRating.LeaderboardModule.Domain;

internal sealed record MatchResult(Guid[] WinnerIds, Guid[] LoserIds);
