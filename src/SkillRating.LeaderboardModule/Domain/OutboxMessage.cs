using Newtonsoft.Json;
using SkillRating.SharedKernel.DateTimeProvider;
using SkillRating.SharedKernel.Events;

namespace SkillRating.LeaderboardModule.Domain;

public sealed class OutboxMessage
{
    private static readonly JsonSerializerSettings JsonSerializerSettings = new()
    {
        TypeNameHandling = TypeNameHandling.All
    };


    private OutboxMessage(
        Guid id,
        DateTime occurredOnUtc,
        string type,
        string content)
    {
        Id = id;
        OccurredOnUtc = occurredOnUtc;
        Type = type;
        Content = content;
    }


    public Guid Id { get; private set; }

    public DateTime OccurredOnUtc { get; private set; }

    public string Type { get; private set; }

    public string Content { get; private set; }

    public DateTime? ProcessedOnUtc { get; private set; }

    public string? Error { get; private set; }


    public static OutboxMessage Create(
        IDomainEvent domainEvent,
        IDateTimeProvider dateTimeProvider)
    {
        return new OutboxMessage(
            Guid.NewGuid(),
            dateTimeProvider.UtcNow,
            domainEvent.GetType().Name,
            JsonConvert.SerializeObject(domainEvent, JsonSerializerSettings));
    }

    public IDomainEvent Deserialize()
    {
        return JsonConvert.DeserializeObject<IDomainEvent>(
            Content,
            JsonSerializerSettings)!;
    }

    public void Process(IDateTimeProvider dateTimeProvider, Exception? error)
    {
        ProcessedOnUtc = dateTimeProvider.UtcNow;
        Error = error?.Message;
    }
}
