using Microsoft.Extensions.Options;
using Quartz;

namespace SkillRating.LeaderboardModule.Infrastructure;

public class ProcessOutboxMessagesJobSetup : IConfigureOptions<QuartzOptions>
{
    public void Configure(QuartzOptions options)
    {
        const string jobName = nameof(ProcessOutboxMessagesJob);

        options
            .AddJob<ProcessOutboxMessagesJob>(configure => configure.WithIdentity(jobName))
            .AddTrigger(configure =>
                configure
                    .ForJob(jobName)
                    .WithSimpleSchedule(schedule =>
                        schedule.WithIntervalInSeconds(30).RepeatForever()));
    }
}
