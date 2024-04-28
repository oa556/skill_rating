using MediatR;
using SkillRating.Api.Contracts.Matches;
using SkillRating.MatchesModule.Domain;
using SkillRating.PlayersModule.Contracts;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.MatchesModule.Application.GetHistory;

internal sealed class GetHistoryQueryHandler(
    IMatchesRepository matchesRepository,
    ISender sender)
    : IQueryHandler<GetHistoryQuery, MatchDto[]>
{
    public async Task<Result<MatchDto[]>> Handle(
        GetHistoryQuery request,
        CancellationToken cancellationToken)
    {
        var matches = await matchesRepository.ListAsync(request.PlayerId, cancellationToken);
        var playerIds = matches
            .SelectMany(m => m.Participants.Select(p => p.PlayerId))
            .Distinct()
            .ToArray();

        var playersByIdResult = await sender.Send(new GetParticipantsQuery(playerIds), cancellationToken);
        if (playersByIdResult.IsFailure)
        {
            return Result.Failure<MatchDto[]>(MatchErrors.NotValid);
        }
        var playersById = playersByIdResult.Value;

        return matches
            .Select(m => new MatchDto(
                m.Id,
                m.CreatorId,
                m.CreatedDateUtc,
                m.Participants
                    .Select(p =>
                    {
                        var player = playersById[p.PlayerId];
                        return new ParticipantDto(player.Id, player.Name, player.ImageUrl, p.IsWinner);
                    })
                    .ToArray()))
            .ToArray();
    }
}
