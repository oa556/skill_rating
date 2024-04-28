namespace SkillRating.MatchesModule.Domain;

public sealed class Participant
{
    internal Participant(
        Guid playerId,
        Guid matchId,
        bool isWinner)
    {
        PlayerId = playerId;
        MatchId = matchId;
        IsWinner = isWinner;
    }


    public Guid PlayerId { get; private set; }

    public Guid MatchId { get; private set; }

    public bool IsWinner { get; private set; }
}
