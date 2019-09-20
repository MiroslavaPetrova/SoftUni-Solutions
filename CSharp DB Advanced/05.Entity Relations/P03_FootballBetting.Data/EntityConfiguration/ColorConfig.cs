using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class ColorConfig : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");

            builder.Property(b => b.Name)
                .IsRequired();

            builder.HasMany(b => b.PrimaryKitTeams)
                .WithOne(b => b.PrimaryKitColor);

            builder.HasMany(b => b.SecondaryKitTeams)
             .WithOne(b => b.SecondaryKitColor);
        }
    }
}
