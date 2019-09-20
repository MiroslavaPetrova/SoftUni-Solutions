using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using P03_FootballBetting.Data.Models;

namespace P03_FootballBetting.Data.EntityConfiguration
{
    public class TownConfig : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.ToTable("Towns");

            builder.Property(t => t.Name)
                .IsRequired();

            builder.HasMany(t => t.Teams)
                .WithOne(t => t.Town);

            builder.HasOne(t => t.Country)
                .WithMany(t => t.Towns);
        }
    }
}
