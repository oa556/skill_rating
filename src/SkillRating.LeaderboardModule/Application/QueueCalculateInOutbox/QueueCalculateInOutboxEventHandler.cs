using MediatR;
using SkillRating.LeaderboardModule.Application.Calculate;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.MatchesModule.Contracts;
using SkillRating.SharedKernel.DateTimeProvider;

namespace SkillRating.LeaderboardModule.Application.QueueCalculateInOutbox;

internal sealed class QueueCalculateInOutboxEventHandler(
    IOutboxMessagesRepository outboxMessagesRepository,
    IDateTimeProvider dateTimeProvider)
    : INotificationHandler<OutcomeEnteredIntegrationEvent>
{
    public async Task Handle(
        OutcomeEnteredIntegrationEvent notification,
        CancellationToken cancellationToken)
    {
        var domainEvent = new LeaderboardCalculatingEvent(notification.MatchId);

        var message = OutboxMessage.Create(domainEvent, dateTimeProvider);

        await outboxMessagesRepository.QueueInOutboxAsync(message);
        await outboxMessagesRepository.SaveChangesAsync();
    }
}
