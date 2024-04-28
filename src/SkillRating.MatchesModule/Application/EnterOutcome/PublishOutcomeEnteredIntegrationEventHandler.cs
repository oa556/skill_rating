using MediatR;
using SkillRating.MatchesModule.Contracts;
using SkillRating.MatchesModule.Domain;

namespace SkillRating.MatchesModule.Application.EnterOutcome;

internal sealed class PublishOutcomeEnteredIntegrationEventHandler(IPublisher publisher)
    : INotificationHandler<OutcomeEnteredDomainEvent>
{
    public async Task Handle(
        OutcomeEnteredDomainEvent notification,
        CancellationToken cancellationToken)
    {
        await publisher.Publish(
            new OutcomeEnteredIntegrationEvent(notification.Id),
            cancellationToken);
    }
}
