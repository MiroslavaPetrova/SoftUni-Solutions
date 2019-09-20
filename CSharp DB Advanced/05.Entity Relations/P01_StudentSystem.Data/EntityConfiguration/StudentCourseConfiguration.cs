namespace P01_StudentSystem.Data.EntityConfiguration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class StudentCourseConfiguration : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasKey(sc => new { sc.CourseId, sc.StudentId });

            builder.HasOne(s => s.Student)
                .WithMany(s => s.CourseEnrollments)
                .HasForeignKey(s => s.StudentId);

            builder.HasOne(c => c.Course)
                .WithMany(c => c.StudentsEnrolled)
                .HasForeignKey(c => c.CourseId);
        }
    }
}
