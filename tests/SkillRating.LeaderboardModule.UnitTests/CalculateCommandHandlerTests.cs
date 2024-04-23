using FluentAssertions;
using SkillRating.LeaderboardModule.Application;
using SkillRating.LeaderboardModule.Domain;
using Xunit;

namespace SkillRating.LeaderboardModule.UnitTests;

public sealed class CalculateCommandHandlerTests
{
    [Fact]
    public async Task CalculatesForIndividuals()
    {
        var expectedPlayerSkills = new PlayerSkill[] {
            new( Id: Guid.NewGuid(), Skill: 100.0000 ),
            new( Id: Guid.NewGuid(), Skill: 78.9114 ),
            new( Id: Guid.NewGuid(), Skill: 52.7376 ),
            new( Id: Guid.NewGuid(), Skill: 1.0000 )
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

        var handler = new CalculateCommandHandler(new InferenceAlgorithm());
        var actualPlayerSkills = await handler.Handle(new CalculateCommand(matches), default);

        AssertEqual(expectedPlayerSkills, actualPlayerSkills);
    }

    [Fact]
    public async Task CalculatesForTeamsAndIndividuals()
    {
        var expectedPlayerSkills = new PlayerSkill[] {
            new( Id: Guid.NewGuid(), Skill: 100.0000 ),
            new( Id: Guid.NewGuid(), Skill: 72.1323 ),
            new( Id: Guid.NewGuid(), Skill: 28.8676 ),
            new( Id: Guid.NewGuid(), Skill: 1.0000 )
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

        var handler = new CalculateCommandHandler(new InferenceAlgorithm());
        var actualPlayerSkills = await handler.Handle(new CalculateCommand(matches), default);

        AssertEqual(expectedPlayerSkills, actualPlayerSkills);
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
        expected.Skill.Should().BeApproximately(actual.Skill, precision: 0.0001);
    }
}
