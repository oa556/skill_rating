using MediatR;

namespace SkillRating.SharedKernel.Events;

public class DomainEventPublisher(IPublisher publisher) : IDomainEventPublisher
{
    public async Task PublishAndClearEvents(Entity[] entitiesWithEvents)
    {
        foreach (var entity in entitiesWithEvents)
        {
            await PublishAndClearEvents(entity);
        }
    }

    private async Task PublishAndClearEvents(Entity entity)
    {
        foreach (var domainEvent in entity.GetDomainEvents())
        {
            await publisher.Publish(domainEvent);
        }

        entity.ClearDomainEvents();
    }
}
