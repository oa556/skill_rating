using SkillRating.SharedKernel.CQRS;

namespace SkillRating.MatchesModule.Application.EnterOutcome;

public sealed record EnterOutcomeCommand(
    Guid PlayerId,
    Guid[] WinnerIds,
    Guid[] LoserIds)
    : ICommand;
