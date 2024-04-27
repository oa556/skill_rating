using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillRating.PlayersModule.Domain;

namespace SkillRating.PlayersModule.Persistence;

internal sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(u => u.Id);

        builder.Property(u => u.Phone)
            .HasConversion(
                phone => phone.Value,
                value => new Phone(value))
            .HasMaxLength(16);

        builder.Property(u => u.Name)
            .HasMaxLength(128);

        builder.Property(u => u.ImageUrl)
            .HasMaxLength(2048);

        builder.HasIndex(p => p.Phone).IsUnique();
    }
}
