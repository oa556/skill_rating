namespace SkillRating.App.Models;

public sealed class Match(Player winner, Player loser)
{
    public Player Winner { get; set; } = winner;
    public Player Loser { get; set; } = loser;
}
