using SkillRating.Api.Contracts.Players;
using SkillRating.SharedKernel.CQRS;

namespace SkillRating.PlayersModule.Application.GetOpponents;

public sealed record GetOpponentsQuery(Guid PlayerId) : IQuery<PlayerDto[]>;
