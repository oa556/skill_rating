using SkillRating.PlayersModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.DateTimeProvider;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.PlayersModule.Application.Register;

internal sealed class RegisterCommandHandler(
    IDateTimeProvider dateTimeProvider,
    IPlayersRepository playersRepository)
    : ICommandHandler<RegisterCommand>
{
    public async Task<Result> Handle(
        RegisterCommand request,
        CancellationToken cancellationToken)
    {
        var player = Player.Register(
            new Phone(request.Phone),
            dateTimeProvider);

        try
        {
            await playersRepository.AddAsync(player);
            await playersRepository.SaveChangesAsync();

            return Result.Success();
        }
        catch
        {
            return Result.Failure(PlayerErrors.PhoneRegistered);
        }
    }
}
