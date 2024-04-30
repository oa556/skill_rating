using SkillRating.MatchesModule.Contracts;
using SkillRating.MatchesModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.MatchesModule.Application.GetAll;

internal sealed class GetAllMatchesQueryHandler(IMatchesRepository matchesRepository)
    : IQueryHandler<GetAllMatchesQuery, MatchResult[]>
{
    public async Task<Result<MatchResult[]>> Handle(
        GetAllMatchesQuery request,
        CancellationToken cancellationToken)
    {
        var matches = await matchesRepository.ListAsync(cancellationToken);

        return matches
            .Select(m => new MatchResult(
                m.Participants
                    .Where(p => p.IsWinner)
                    .Select(p => p.PlayerId)
                    .ToArray(),
                m.Participants
                    .Where(p => !p.IsWinner)
                    .Select(p => p.PlayerId)
                    .ToArray()))
            .ToArray();
    }
}
