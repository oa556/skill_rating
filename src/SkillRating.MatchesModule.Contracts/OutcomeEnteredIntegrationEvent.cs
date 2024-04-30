using SkillRating.SharedKernel.Events;

namespace SkillRating.MatchesModule.Contracts;

public sealed record OutcomeEnteredIntegrationEvent(Guid MatchId) : IIntegrationEvent;
