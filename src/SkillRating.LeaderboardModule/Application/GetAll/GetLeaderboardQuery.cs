using SkillRating.Api.Contracts.Leaderboard;
using SkillRating.SharedKernel.CQRS;

namespace SkillRating.LeaderboardModule.Application.GetAll;

public sealed record GetLeaderboardQuery : IQuery<LeaderboardEntryDto[]>;
