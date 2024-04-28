namespace SkillRating.Api.Contracts.Matches;

public sealed record EnterOutcomeRequest(Guid[] WinnerIds, Guid[] LoserIds);
