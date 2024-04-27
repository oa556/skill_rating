using SkillRating.Api.Contracts.Players;
using SkillRating.SharedKernel.CQRS;

namespace SkillRating.PlayersModule.Contracts;

public sealed record GetParticipantsQuery(Guid[] Ids) : IQuery<Dictionary<Guid, PlayerDto>>;
