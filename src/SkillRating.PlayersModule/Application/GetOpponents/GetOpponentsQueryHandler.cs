using SkillRating.Api.Contracts.Players;
using SkillRating.PlayersModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.PlayersModule.Application.GetOpponents;

internal sealed class GetOpponentsQueryHandler(IPlayersRepository playersRepository)
    : IQueryHandler<GetOpponentsQuery, PlayerDto[]>
{
    public async Task<Result<PlayerDto[]>> Handle(
        GetOpponentsQuery request,
        CancellationToken cancellationToken)
    {
        var players = await playersRepository.ListAsync(request.PlayerId, cancellationToken);

        return players
            .Select(p => new PlayerDto(p.Id, p.Name, p.ImageUrl))
            .ToArray();
    }
}
