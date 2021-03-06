﻿namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class CourseConfiguration : IEntityTypeConfiguration<Course>

    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.CourseId);

            builder.Property(c => c.Name)
                .HasMaxLength(80)
                .IsUnicode()
                .IsRequired();

            builder.HasMany(c => c.StudentsEnrolled)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder.HasMany(c => c.Resources)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);

            builder.HasMany(c => c.HomeworkSubmissions)
                .WithOne(c => c.Course)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
