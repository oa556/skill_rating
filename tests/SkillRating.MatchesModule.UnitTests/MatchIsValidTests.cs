using FluentAssertions;
using NSubstitute;
using SkillRating.MatchesModule.Domain;
using SkillRating.SharedKernel.DateTimeProvider;
using Xunit;

namespace SkillRating.MatchesModule.UnitTests;

public class MatchIsValidTests
{
    private readonly IDateTimeProvider _dateTimeProvider = Substitute.For<IDateTimeProvider>();
 
    [Fact]
    public void IsValidWhenTeamsAreValid()
    {
        Guid[] winners = [Guid.NewGuid(), Guid.NewGuid()];
        Guid[] losers = [Guid.NewGuid(), Guid.NewGuid()];

        var match = Match.EnterOutcome(
            winners[0],
            winners,
            losers,
            _dateTimeProvider);

        match.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public void IsNotValidWhenTeamsAreOfDifferentSize()
    {
        Guid[] winners = [Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid()];
        Guid[] losers = [Guid.NewGuid(), Guid.NewGuid()];

        var match = Match.EnterOutcome(
            winners[0],
            winners,
            losers,
            _dateTimeProvider);

        match.IsFailure.Should().BeTrue();
        match.Error.Should().Be(MatchErrors.NotValid);
    }

    [Fact]
    public void IsNotValidWhenLosingTeamContainsDuplicatePlayerIds()
    {
        var duplicateId = Guid.NewGuid();
        Guid[] winners = [Guid.NewGuid(), Guid.NewGuid()];
        Guid[] losers = [duplicateId, duplicateId];

        var match = Match.EnterOutcome(
            winners[0],
            winners,
            losers,
            _dateTimeProvider);

        match.IsFailure.Should().BeTrue();
        match.Error.Should().Be(MatchErrors.NotValid);
    }

    [Fact]
    public void IsNotValidWhenWinningAndLosingTeamsContainDuplicatePlayerIds()
    {
        var duplicateId = Guid.NewGuid();
        Guid[] winners = [duplicateId, Guid.NewGuid()];
        Guid[] losers = [duplicateId, Guid.NewGuid()];

        var match = Match.EnterOutcome(
            winners[0],
            winners,
            losers,
            _dateTimeProvider);

        match.IsFailure.Should().BeTrue();
        match.Error.Should().Be(MatchErrors.NotValid);
    }

    [Fact]
    public void IsNotValidWhenCreatorIdIsNotInWinnerIdsOrLoserIds()
    {
        Guid[] winners = [Guid.NewGuid(), Guid.NewGuid()];
        Guid[] losers = [Guid.NewGuid(), Guid.NewGuid()];

        var match = Match.EnterOutcome(
            Guid.NewGuid(),
            winners,
            losers,
            _dateTimeProvider);

        match.IsFailure.Should().BeTrue();
        match.Error.Should().Be(MatchErrors.NotValid);
    }
}
