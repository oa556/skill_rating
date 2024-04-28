using SkillRating.MatchesModule.Domain;
using SkillRating.SharedKernel.CQRS;
using SkillRating.SharedKernel.DateTimeProvider;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.MatchesModule.Application.EnterOutcome;

internal sealed class EnterOutcomeCommandHandler(
    IDateTimeProvider dateTimeProvider,
    IMatchesRepository matchesRepository)
    : ICommandHandler<EnterOutcomeCommand>
{
    public async Task<Result> Handle(
        EnterOutcomeCommand request,
        CancellationToken cancellationToken)
    {
        var matchResult = Match.EnterOutcome(
            request.PlayerId,
            request.WinnerIds,
            request.LoserIds,
            dateTimeProvider);
        if (matchResult.IsFailure)
        {
            return Result.Failure(matchResult.Error);
        }

        await matchesRepository.AddAsync(matchResult.Value);
        await matchesRepository.SaveChangesAsync();

        return Result.Success();
    }
}
