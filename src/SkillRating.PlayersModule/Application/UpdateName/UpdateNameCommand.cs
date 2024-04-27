using SkillRating.SharedKernel.CQRS;

namespace SkillRating.PlayersModule.Application.UpdateName;

public sealed record UpdateNameCommand(Guid PlayerId, string Name)
    : ICommand;
