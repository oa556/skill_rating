using SkillRating.PlayersModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.PlayersModule.Application.UpdateImage;

internal sealed class UpdateImageCommandHandler(IPlayersRepository playersRepository)
    : ICommandHandler<UpdateImageCommand>
{
    public async Task<Result> Handle(
        UpdateImageCommand request,
        CancellationToken cancellationToken)
    {
        var player = await playersRepository.GetByIdAsync(request.PlayerId);
        if (player == null)
        {
            return Result.Failure(PlayerErrors.NotFound);
        }

        player.UpdateImageUrl(request.ImageUrl);
        await playersRepository.SaveChangesAsync();

        return Result.Success();
    }
}
