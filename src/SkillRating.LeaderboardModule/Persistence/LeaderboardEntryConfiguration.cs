using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillRating.LeaderboardModule.Domain;

namespace SkillRating.LeaderboardModule.Persistence;

internal sealed class LeaderboardEntryConfiguration
    : IEntityTypeConfiguration<LeaderboardEntry>
{
    public void Configure(EntityTypeBuilder<LeaderboardEntry> builder)
    {
        builder.HasKey(le => le.PlayerId);
    }
}
