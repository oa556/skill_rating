using SkillRating.SharedKernel.DateTimeProvider;
using SkillRating.SharedKernel.Events;
using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.MatchesModule.Domain;

public sealed class Match : Entity
{
    private Match(
        Guid id,
        Guid creatorId,
        DateTime createdDateUtc)
    {
        Id = id;
        CreatorId = creatorId;
        CreatedDateUtc = createdDateUtc;
    }


    public Guid Id { get; private set; }

    public Guid CreatorId { get; private set; }

    public DateTime CreatedDateUtc { get; private set; }

    private readonly List<Participant> _participants = [];
    public IReadOnlyCollection<Participant> Participants => _participants;


    public static Result<Match> EnterOutcome(
        Guid creatorId,
        Guid[] winnerIds,
        Guid[] loserIds,
        IDateTimeProvider dateTimeProvider)
    {
        if (!IsValid(creatorId, winnerIds, loserIds))
        {
            return Result.Failure<Match>(MatchErrors.NotValid);
        }

        var match = new Match(
            Guid.NewGuid(),
            creatorId,
            dateTimeProvider.UtcNow);

        match._participants.AddRange(
            winnerIds.Select(playerId =>
                new Participant(playerId, match.Id, isWinner: true)));

        match._participants.AddRange(
            loserIds.Select(playerId =>
                new Participant(playerId, match.Id, isWinner: false)));

        match.RaiseDomainEvent(new OutcomeEnteredDomainEvent(match.Id));

        return match;
    }

    private static bool IsValid(
        Guid creatorId,
        Guid[] winnerIds,
        Guid[] loserIds)
    {
        if (winnerIds.Length != loserIds.Length)
        {
            return false;
        }

        var allIds = winnerIds.Concat(loserIds).ToArray();
        return allIds.Distinct().Count() == allIds.Length && allIds.Contains(creatorId);
    }
}
