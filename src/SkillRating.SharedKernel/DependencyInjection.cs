using Microsoft.Extensions.DependencyInjection;
using SkillRating.SharedKernel.DateTimeProvider;
using SkillRating.SharedKernel.Events;

namespace SkillRating.SharedKernel;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedKernel(this IServiceCollection services)
    {
        services.AddTransient<IDateTimeProvider, DateTimeProvider.DateTimeProvider>();

        services.AddScoped<IDomainEventPublisher, DomainEventPublisher>();

        return services;
    }
}
