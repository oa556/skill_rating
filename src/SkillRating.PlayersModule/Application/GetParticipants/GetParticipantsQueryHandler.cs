using SkillRating.Api.Contracts.Players;
using SkillRating.PlayersModule.Contracts;
using SkillRating.PlayersModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.PlayersModule.Application.GetParticipants;

internal sealed class GetParticipantsQueryHandler(IPlayersRepository playersRepository)
    : IQueryHandler<GetParticipantsQuery, Dictionary<Guid, PlayerDto>>
{
    public async Task<Result<Dictionary<Guid, PlayerDto>>> Handle(
        GetParticipantsQuery request,
        CancellationToken cancellationToken)
    {
        var players = await playersRepository.ListAsync(request.Ids, cancellationToken);

        return players
            .Select(p => new PlayerDto(p.Id, p.Name, p.ImageUrl))
            .ToDictionary(p => p.Id);
    }
}
