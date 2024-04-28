namespace SkillRating.Api.Contracts.Matches;

public sealed record MatchDto(
    Guid Id,
    Guid CreatorId,
    DateTime CreatedDateUtc,
    ParticipantDto[] Participants);
