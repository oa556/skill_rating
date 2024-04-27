namespace SkillRating.SharedKernel.DateTimeProvider;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
