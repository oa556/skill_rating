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
        return await playersRepository.ListAsync(request.PlayerId, cancellationToken);
    }
}
