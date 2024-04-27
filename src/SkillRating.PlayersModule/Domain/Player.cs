using SkillRating.SharedKernel.DateTimeProvider;

namespace SkillRating.PlayersModule.Domain;

public sealed class Player
{
    private Player(
        Guid id,
        Phone phone,
        DateTime registeredDateTimeUtc)
    {
        Id = id;
        Phone = phone;
        RegisteredDateTimeUtc = registeredDateTimeUtc;
    }


    public Guid Id { get; private set; }

    public Phone Phone { get; private set; }

    public string? Name { get; private set; }

    public string? ImageUrl { get; private set; }

    public DateTime RegisteredDateTimeUtc { get; private set; }


    public static Player Register(Phone phone, IDateTimeProvider dateTimeProvider)
    {
        return new Player(
            Guid.NewGuid(),
            phone,
            dateTimeProvider.UtcNow);
    }

    public void UpdateName(string name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            Name = name;
        }
    }

    public void UpdateImageUrl(string imageUrl)
    {
        if (!string.IsNullOrWhiteSpace(imageUrl))
        {
            ImageUrl = imageUrl;
        }
    }
}
