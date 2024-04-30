using SkillRating.Api.Contracts.Leaderboard;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.LeaderboardModule.Application.GetAll;

internal sealed class GetLeaderboardQueryHandler(ILeaderboardRepository leaderboardRepository)
    : IQueryHandler<GetLeaderboardQuery, LeaderboardEntryDto[]>
{
    public async Task<Result<LeaderboardEntryDto[]>> Handle(
        GetLeaderboardQuery request,
        CancellationToken cancellationToken)
    {
        var entries = await leaderboardRepository.ListAsync(cancellationToken);

        return entries
            .Select(e => new LeaderboardEntryDto(
                e.PlayerId, e.Skill, e.MatchesPlayed, e.Name, e.ImageUrl))
            .OrderByDescending(le => le.Skill)
            .ToArray();
    }
}
