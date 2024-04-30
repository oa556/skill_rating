using MediatR;
using Quartz;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.SharedKernel.DateTimeProvider;

namespace SkillRating.LeaderboardModule.Infrastructure;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxMessagesJob(
    IOutboxMessagesRepository outboxMessagesRepository,
    IPublisher publisher,
    IDateTimeProvider dateTimeProvider)
    : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        var outboxMessages = await outboxMessagesRepository.ListAsync();

        foreach (var outboxMessage in outboxMessages)
        {
            Exception? exception = null;

            try
            {
                var domainEvent = outboxMessage.Deserialize();

                await publisher.Publish(domainEvent, context.CancellationToken);
            }
            catch (Exception caughtException)
            {
                exception = caughtException;
            }

            outboxMessage.Process(dateTimeProvider, exception);
        }

        await outboxMessagesRepository.SaveChangesAsync();
    }
}
