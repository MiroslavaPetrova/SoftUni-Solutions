using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.HasOne(t => t.PrimaryKitColor)
                .WithMany(t => t.PrimaryKitTeams);

            builder.HasOne(t => t.SecondaryKitColor)
                .WithMany(t => t.SecondaryKitTeams);

            builder.HasOne(t => t.Town)
               .WithMany(t => t.Teams);

            builder.HasMany(t => t.Players)
                .WithOne(t => t.Team);

            builder.HasMany(t => t.HomeGames)
               .WithOne(t => t.HomeTeam);

            builder.HasMany(t => t.AwayGames)
               .WithOne(t => t.AwayTeam);
        }
    }
}
