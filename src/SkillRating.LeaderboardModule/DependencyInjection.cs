using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.LeaderboardModule.Infrastructure;
using SkillRating.LeaderboardModule.Persistence;

namespace SkillRating.LeaderboardModule;

public static class DependencyInjection
{
    public static IServiceCollection AddLeaderboardModule(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatRAssemblies)
    {
        var connectionString = configuration.GetConnectionString("LeaderboardDatabase")
                               ?? throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<LeaderboardDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IOutboxMessagesRepository, OutboxMessagesRepository>();
        services.AddScoped<ILeaderboardRepository, LeaderboardRepository>();

        services.AddSingleton<InferenceAlgorithm>();

        services.AddQuartz();
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);
        services.ConfigureOptions<ProcessOutboxMessagesJobSetup>();

        mediatRAssemblies.Add(typeof(ILeaderboardModule).Assembly);

        return services;
    }
}
