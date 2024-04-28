namespace SkillRating.Api.Contracts.Matches;

public record ParticipantDto(
    Guid Id,
    string? Name,
    string? ImageUrl,
    bool IsWinner);
