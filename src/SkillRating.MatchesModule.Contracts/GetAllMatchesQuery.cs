using SkillRating.SharedKernel.CQRS;

namespace SkillRating.MatchesModule.Contracts;

public sealed record GetAllMatchesQuery : IQuery<MatchResult[]>;
