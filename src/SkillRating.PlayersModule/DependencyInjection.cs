using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SkillRating.PlayersModule.Domain;
using SkillRating.PlayersModule.Persistence;

namespace SkillRating.PlayersModule;

public static class DependencyInjection
{
    public static IServiceCollection AddPlayersModule(
        this IServiceCollection services,
        IConfiguration configuration,
        List<Assembly> mediatRAssemblies)
    {
        var connectionString = configuration.GetConnectionString("PlayersDatabase")
                               ?? throw new ArgumentNullException(nameof(configuration));
        services.AddDbContext<PlayersDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<IPlayersRepository, PlayersRepository>();

        mediatRAssemblies.Add(typeof(IPlayersModule).Assembly);

        return services;
    }
}
