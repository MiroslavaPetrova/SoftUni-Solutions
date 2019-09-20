using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class PlayerStatisticConfig : IEntityTypeConfiguration<PlayerStatistic>
    {
        public void Configure(EntityTypeBuilder<PlayerStatistic> builder)
        {
            builder.ToTable("PlayerStatistics");

            builder.HasKey(ps => new { ps.PlayerId, ps.GameId });

            builder.HasOne(p => p.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(p => p.PlayerId);

            builder.HasOne(p => p.Game)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(p => p.GameId);
        }
    }
}
