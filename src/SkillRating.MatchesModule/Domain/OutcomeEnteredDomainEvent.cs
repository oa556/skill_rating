using SkillRating.SharedKernel.Events;

namespace SkillRating.MatchesModule.Domain;

public sealed record OutcomeEnteredDomainEvent(Guid Id) : IDomainEvent;
