using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.MatchesModule.Domain;

public static class MatchErrors
{
    public static readonly Error NotValid = new(
        "Match.NotValid",
        "Participants not valid");
}
