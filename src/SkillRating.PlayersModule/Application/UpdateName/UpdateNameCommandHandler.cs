using SkillRating.PlayersModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.PlayersModule.Application.UpdateName;

internal sealed class UpdateNameCommandHandler(IPlayersRepository playersRepository)
    : ICommandHandler<UpdateNameCommand>
{
    public async Task<Result> Handle(
        UpdateNameCommand request,
        CancellationToken cancellationToken)
    {
        var player = await playersRepository.GetByIdAsync(request.PlayerId);
        if (player == null)
        {
            return Result.Failure(PlayerErrors.NotFound);
        }

        player.UpdateName(request.Name);
        await playersRepository.SaveChangesAsync();

        return Result.Success();
    }
}
