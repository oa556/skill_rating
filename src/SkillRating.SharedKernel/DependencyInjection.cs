using Microsoft.Extensions.DependencyInjection;
using SkillRating.SharedKernel.DateTimeProvider;

namespace SkillRating.SharedKernel;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider.DateTimeProvider>();

        return services;
    }
}
