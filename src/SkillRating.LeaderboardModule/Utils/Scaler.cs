using Microsoft.ML.Probabilistic.Distributions;

namespace SkillRating.LeaderboardModule.Utils;

internal sealed class Scaler(
    double sourceRangeStart,
    double sourceRangeEnd,
    double targetRangeStart = Scaler.DefaultTargetRangeStart,
    double targetRangeEnd = Scaler.DefaultTargetRangeEnd)
{
    private const double DefaultTargetRangeStart = 1.0;
    private const double DefaultTargetRangeEnd = 100.0;

    private double SourceRangeStart { get; } = sourceRangeStart;
    private double TargetRangeStart { get; } = targetRangeStart;
    private double ScaleFactor { get; } = (targetRangeEnd - targetRangeStart) / (sourceRangeEnd - sourceRangeStart);

    public double Scale(Gaussian skill)
    {
        return TargetRangeStart + (skill.GetMean() - SourceRangeStart) * ScaleFactor;
    }
}
