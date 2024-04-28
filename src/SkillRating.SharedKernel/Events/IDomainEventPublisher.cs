namespace SkillRating.SharedKernel.Events;

public interface IDomainEventPublisher
{
    Task PublishAndClearEvents(Entity[] entitiesWithEvents);
}
