using SkillRating.SharedKernel.CQRS;

namespace SkillRating.PlayersModule.Application.Register;

public sealed record RegisterCommand(string Phone) : ICommand;
