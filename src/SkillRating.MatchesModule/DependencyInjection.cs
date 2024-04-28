using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillRating.MatchesModule.Domain;
using SkillRating.MatchesModule.Persistence;

namespace SkillRating.MatchesModule;

public static class DependencyInjection
{
    public static IServiceCollection AddMatchesModule(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MatchesDatabase")
                               ?? throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<MatchesDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IMatchesRepository, MatchesRepository>();

        return services;
    }
}
