using Microsoft.ML.Probabilistic.Distributions;
using Microsoft.ML.Probabilistic.Models;
using Range = Microsoft.ML.Probabilistic.Models.Range;

namespace SkillRating.LeaderboardModule.Domain;

internal sealed class InferenceAlgorithm
{
    private const double PerformanceVariance = 1.0;
    private const int SkillsMean = 6;
    private const int SkillsVariance = 9;

    public Gaussian[] Infer(ObservedParameters parameters)
    {
        // Matches
        var matchCount = Variable.Observed(default(int));
        var matches = new Range(matchCount);

        // Players
        var playerCount = Variable.Observed(default(int));
        var players = new Range(playerCount);

        // Player skills
        var playerSkills = Variable.Array<double>(players);
        playerSkills[players] = Variable.GaussianFromMeanAndVariance(SkillsMean, SkillsVariance).ForEach(players);

        // Winning teams
        var winningTeamPlayerCounts = Variable.Observed(default(int[]), matches);
        var winningTeamPlayers = new Range(winningTeamPlayerCounts[matches]);

        // Losing teams
        var losingTeamPlayerCounts = Variable.Observed(default(int[]), matches);
        var losingTeamPlayers = new Range(losingTeamPlayerCounts[matches]);

        // Winning and losing teams
        var winningAndLosingTeamPlayerCounts = Variable.Array<int>(matches);
        winningAndLosingTeamPlayerCounts[matches] = winningTeamPlayerCounts[matches] + losingTeamPlayerCounts[matches];
        var winningAndLosingTeamPlayers = new Range(winningAndLosingTeamPlayerCounts[matches]);
        var winningAndLosingTeams = Variable.Observed(default(int[][]), matches, winningAndLosingTeamPlayers);

        using (Variable.ForEach(matches))
        {
            // Split players into winning and losing teams
            var winningAndLosingTeamPlayerSkills = Variable.Subarray(playerSkills, winningAndLosingTeams[matches]);
            var winningTeamPlayerSkills = Variable.Split(winningAndLosingTeamPlayerSkills, winningTeamPlayers, losingTeamPlayers, out var losingTeamPlayerSkills);

            // Winning team performance
            var winningTeamPerformances = Variable.Array<double>(winningTeamPlayers);
            winningTeamPerformances[winningTeamPlayers] = Variable.GaussianFromMeanAndVariance(winningTeamPlayerSkills[winningTeamPlayers], PerformanceVariance);
            var winningTeamPerformance = Variable.Sum(winningTeamPerformances);

            // Losing team performance
            var losingTeamPerformances = Variable.Array<double>(losingTeamPlayers);
            losingTeamPerformances[losingTeamPlayers] = Variable.GaussianFromMeanAndVariance(losingTeamPlayerSkills[losingTeamPlayers], PerformanceVariance);
            var losingTeamPerformance = Variable.Sum(losingTeamPerformances);

            // The winning team performed better in this match
            Variable.ConstrainTrue(winningTeamPerformance > losingTeamPerformance);
        }

        // Attach the data to the model
        matchCount.ObservedValue = parameters.MatchCount;
        playerCount.ObservedValue = parameters.PlayerCount;
        winningTeamPlayerCounts.ObservedValue = parameters.WinningTeamPlayerCounts;
        losingTeamPlayerCounts.ObservedValue = parameters.LosingTeamPlayerCounts;
        winningAndLosingTeams.ObservedValue = parameters.WinningAndLosingTeams;

        // Run inference
        return new InferenceEngine().Infer<Gaussian[]>(playerSkills);
    }
}
