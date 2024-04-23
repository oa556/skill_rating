using MediatR;
using SkillRating.LeaderboardModule.Domain;

namespace SkillRating.LeaderboardModule.Application;

internal sealed record CalculateCommand(MatchResult[] Matches)
    : IRequest<PlayerSkill[]>;
