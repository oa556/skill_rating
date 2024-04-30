using MediatR;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.LeaderboardModule.Utils;
using SkillRating.MatchesModule.Contracts;
using SkillRating.PlayersModule.Contracts;

namespace SkillRating.LeaderboardModule.Application.Calculate;

internal sealed class InferenceAlgorithm(
    Domain.InferenceAlgorithm inferenceAlgorithm,
    ISender sender,
    ILeaderboardRepository leaderboardRepository)
    : INotificationHandler<LeaderboardCalculatingEvent>
{
    public async Task Handle(
        LeaderboardCalculatingEvent request,
        CancellationToken cancellationToken)
    {
        var getAllMatchesQuery = new GetAllMatchesQuery();
        var matchesResult = await sender.Send(getAllMatchesQuery, cancellationToken);
        var matches = matchesResult.Value;

        var parameters = new ObservedParameters(matches);
        var inferredSkills = inferenceAlgorithm.Infer(parameters);

        var scaler = new Scaler(
            inferredSkills.Min(g => g.GetMean()),
            inferredSkills.Max(g => g.GetMean()));
        var playerSkills = inferredSkills
            .Select((g, i) =>
            {
                var id = parameters.GetPlayerId(i);
                var skill = scaler.Scale(g);
                return new PlayerSkill(id, skill);
            })
            .ToArray();

        var getParticipantsQuery = new GetParticipantsQuery(
            playerSkills.Select(p => p.Id).ToArray());
        var playersResult = await sender.Send(getParticipantsQuery, cancellationToken);
        var players = playersResult.Value;

        var winnerIds = matches.SelectMany(m => m.WinnerIds);
        var loserIds = matches.SelectMany(m => m.LoserIds);
        var flattenedIds = winnerIds.Concat(loserIds).ToArray();
        var matchesPlayedById = playerSkills
            .Select(ps => new
            {
                ps.Id,
                MatchesPlayed = flattenedIds.Count(id => id == ps.Id)
            })
            .ToDictionary(ps => ps.Id, ps => ps.MatchesPlayed);

        var leaderboardEntries = playerSkills
            .Select(ps => new LeaderboardEntry(
                ps.Id,
                ps.Skill,
                matchesPlayedById[ps.Id],
                players[ps.Id].Name,
                players[ps.Id].ImageUrl))
            .ToArray();

        await leaderboardRepository.UpdateLeaderboardAsync(leaderboardEntries);
    }
}
