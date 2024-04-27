namespace SkillRating.Api.Contracts.Players;

public sealed record PlayerDto(
    Guid Id,
    string? Name,
    string? ImageUrl);
