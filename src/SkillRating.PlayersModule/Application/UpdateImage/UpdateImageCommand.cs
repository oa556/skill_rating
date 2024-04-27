using SkillRating.SharedKernel.CQRS;

namespace SkillRating.PlayersModule.Application.UpdateImage;

public sealed record UpdateImageCommand(Guid PlayerId, string ImageUrl)
    : ICommand;
