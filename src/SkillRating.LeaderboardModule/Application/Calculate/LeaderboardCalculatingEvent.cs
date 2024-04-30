using SkillRating.SharedKernel.Events;

namespace SkillRating.LeaderboardModule.Application.Calculate;

internal sealed record LeaderboardCalculatingEvent(Guid MatchId)
    : IDomainEvent;
