using SkillRating.LeaderboardModule.Utils;
using SkillRating.MatchesModule.Contracts;

namespace SkillRating.LeaderboardModule.Domain;

internal sealed class ObservedParameters
{
    public int MatchCount { get; }
    public int PlayerCount { get; }
    public int[][] WinningAndLosingTeams { get; }
    public int[] WinningTeamPlayerCounts { get; }
    public int[] LosingTeamPlayerCounts { get; }

    private readonly LookupTable _playerLookupTable = new();

    public ObservedParameters(MatchResult[] matches)
    {
        WinningTeamPlayerCounts = new int[matches.Length];
        LosingTeamPlayerCounts = new int[matches.Length];
        WinningAndLosingTeams = new int[matches.Length][];

        for (var i = 0; i < matches.Length; ++i)
        {
            var winners = matches[i].WinnerIds.Select(w => _playerLookupTable.GetIndex(w)).ToArray();
            WinningTeamPlayerCounts[i] = winners.Length;

            var losers = matches[i].LoserIds.Select(l => _playerLookupTable.GetIndex(l)).ToArray();
            LosingTeamPlayerCounts[i] = losers.Length;

            WinningAndLosingTeams[i] = winners.Concat(losers).ToArray();
        }

        MatchCount = matches.Length;
        PlayerCount = _playerLookupTable.Count;
    }

    public Guid GetPlayerId(int index)
    {
        return _playerLookupTable.GetId(index);
    }
}
