namespace SkillRating.App.Models;

public sealed class Player(
    Guid id,
    string? name,
    string? imageUrl)
{
    public Guid Id { get; set; } = id;

    public string? Name { get; set; } = name;

    public string? ImageUrl { get; set; } = imageUrl;
}
