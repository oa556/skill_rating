namespace SkillRating.MatchesModule.Contracts;

public sealed record MatchResult(Guid[] WinnerIds, Guid[] LoserIds);
