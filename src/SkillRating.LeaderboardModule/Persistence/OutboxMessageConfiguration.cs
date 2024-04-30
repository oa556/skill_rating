using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillRating.LeaderboardModule.Domain;

namespace SkillRating.LeaderboardModule.Persistence;

internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
    public void Configure(EntityTypeBuilder<OutboxMessage> builder)
    {
        builder.Property(om => om.Type)
            .HasMaxLength(128);

        builder.Property(om => om.Content)
            .HasMaxLength(1024);

        builder.Property(om => om.Error)
            .HasMaxLength(1024);
    }
}
