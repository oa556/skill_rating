using FluentAssertions;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.LeaderboardModule.Utils;
using SkillRating.MatchesModule.Contracts;
using Xunit;

namespace SkillRating.LeaderboardModule.UnitTests;

public sealed class InferenceAlgorithmTests
{
    [Fact]
    public void InfersSkillsForIndividuals()
    {
        var expectedPlayerSkills = new PlayerSkill[] {
            new( Id: Guid.NewGuid(), Skill: 100 ),
            new( Id: Guid.NewGuid(), Skill: 79 ),
            new( Id: Guid.NewGuid(), Skill: 53 ),
            new( Id: Guid.NewGuid(), Skill: 1 )
        };
        var matches = new MatchResult[]
        {
            new(
                WinnerIds: [ expectedPlayerSkills[0].Id ],
                LoserIds: [ expectedPlayerSkills[2].Id ]), // 1 > 3
            new(
                WinnerIds: [ expectedPlayerSkills[1].Id ],
                LoserIds: [ expectedPlayerSkills[3].Id ]), // 2 > 4
            new(
                WinnerIds: [ expectedPlayerSkills[2].Id ],
                LoserIds: [ expectedPlayerSkills[3].Id ]) // 3 > 4
        };

        var actualPlayerSkills = CalculateSkills(matches);

        AssertEqual(expectedPlayerSkills, actualPlayerSkills);
    }

    [Fact]
    public void InfersSkillsForTeamsAndIndividuals()
    {
        var expectedPlayerSkills = new PlayerSkill[] {
            new( Id: Guid.NewGuid(), Skill: 100 ),
            new( Id: Guid.NewGuid(), Skill: 72 ),
            new( Id: Guid.NewGuid(), Skill: 29 ),
            new( Id: Guid.NewGuid(), Skill: 1 )
        };
        var matches = new MatchResult[]
        {
            new(
                WinnerIds: [ expectedPlayerSkills[0].Id, expectedPlayerSkills[1].Id ],
                LoserIds: [ expectedPlayerSkills[2].Id, expectedPlayerSkills[3].Id ]), // 1, 2 > 3, 4
            new(
                WinnerIds: [ expectedPlayerSkills[0].Id, expectedPlayerSkills[2].Id ],
                LoserIds: [ expectedPlayerSkills[1].Id, expectedPlayerSkills[3].Id ]), // 1, 3 > 2, 4
            new(
                WinnerIds: [ expectedPlayerSkills[1].Id ],
                LoserIds: [ expectedPlayerSkills[2].Id ]) // 2 > 3
        };

        var actualPlayerSkills = CalculateSkills(matches);

        AssertEqual(expectedPlayerSkills, actualPlayerSkills);
    }


    private static PlayerSkill[] CalculateSkills(MatchResult[] matches)
    {
        var parameters = new ObservedParameters(matches);
        var inferredSkills = new InferenceAlgorithm().Infer(parameters);
        var scaler = new Scaler(
            inferredSkills.Min(g => g.GetMean()),
            inferredSkills.Max(g => g.GetMean()));

        return inferredSkills
            .Select((g, i) =>
            {
                var id = parameters.GetPlayerId(i);
                var skill = scaler.Scale(g);
                return new PlayerSkill(id, skill);
            })
            .OrderByDescending(ps => ps.Skill)
            .ToArray();
    }

    private static void AssertEqual(PlayerSkill[] expected, PlayerSkill[] actual)
    {
        expected.Length.Should().Be(actual.Length);

        for (var i = 0; i < expected.Length; ++i)
        {
            AssertEqual(expected[i], actual[i]);
        }
    }

    private static void AssertEqual(PlayerSkill expected, PlayerSkill actual)
    {
        expected.Id.Should().Be(actual.Id);
        expected.Skill.Should().Be(actual.Skill);
    }
}
