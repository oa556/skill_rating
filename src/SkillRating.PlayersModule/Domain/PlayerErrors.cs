using SkillRating.SharedKernel.ResultObject;

namespace SkillRating.PlayersModule.Domain;

public static class PlayerErrors
{
    public static readonly Error NotFound = new(
        "Player.NotFound",
        "Player not found");

    public static readonly Error PhoneRegistered = new(
        "Player.PhoneRegistered",
        "Phone is already registered");
}
