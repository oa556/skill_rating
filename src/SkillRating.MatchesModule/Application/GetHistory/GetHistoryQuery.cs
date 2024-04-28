using SkillRating.Api.Contracts.Matches;
using SkillRating.SharedKernel.CQRS;

namespace SkillRating.MatchesModule.Application.GetHistory;

public sealed record GetHistoryQuery(Guid PlayerId) : IQuery<MatchDto[]>;
