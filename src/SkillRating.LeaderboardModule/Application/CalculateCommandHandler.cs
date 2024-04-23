using MediatR;
using SkillRating.LeaderboardModule.Domain;
using SkillRating.LeaderboardModule.Utils;

namespace SkillRating.LeaderboardModule.Application;

internal sealed class CalculateCommandHandler(InferenceAlgorithm inferenceAlgorithm)
    : IRequestHandler<CalculateCommand, PlayerSkill[]>
{
    public Task<PlayerSkill[]> Handle(
        CalculateCommand request,
        CancellationToken cancellationToken)
    {
        // Prepare parameters and run inference
        var parameters = new ObservedParameters(request.Matches);
        var inferredSkills = InferenceAlgorithm.Infer(parameters);

        // Scale and map player skills
        var scaler = new Scaler(
            inferredSkills.Min(g => g.GetMean()),
            inferredSkills.Max(g => g.GetMean()));
        var playerSkills = inferredSkills
            .Select((g, i) =>
            {
                var id = parameters.GetPlayerId(i);
                var skill = scaler.Scale(g);
                return new PlayerSkill(id, skill);
            })
            .OrderByDescending(ps => ps.Skill)
            .ToArray();

        return Task.FromResult(playerSkills);
    }
}
