namespace SkillRating.SharedKernel.DateTimeProvider;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
