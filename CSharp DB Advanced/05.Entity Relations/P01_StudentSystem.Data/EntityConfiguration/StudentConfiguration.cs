namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.StudentId);

            builder.Property(s => s.Name)
                .HasMaxLength(100)
                .IsUnicode()
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .HasColumnType("CHAR(10)")
                .IsUnicode(false)
                .IsRequired(false);

            builder.HasMany(s => s.CourseEnrollments)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);

            builder.HasMany(s => s.HomeworkSubmissions)
                .WithOne(s => s.Student)
                .HasForeignKey(s => s.StudentId);
        }
    }
}
