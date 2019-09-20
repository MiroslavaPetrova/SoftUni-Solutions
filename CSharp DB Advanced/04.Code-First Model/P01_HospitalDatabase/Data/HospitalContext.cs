using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        { }

        public HospitalContext(DbContextOptions options)
        { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<Diagnose> Diagnoses{ get; set; }
        public DbSet<Visitation> Visitations{ get; set; }
        public DbSet<PatientMedicament> PatientMedicaments{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //TODO apply for the Doctor class relation & maxlength
            modelBuilder.Entity<Patient>().HasKey(k => new { k.PatientId });
            modelBuilder.Entity<Patient>().Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsUnicode();
            modelBuilder.Entity<Patient>().Property(p => p.LastName)
                .HasMaxLength(50)
                .IsUnicode();
            modelBuilder.Entity<Patient>().Property(p => p.Address)
                .HasMaxLength(250)
                .IsUnicode();
            modelBuilder.Entity<Patient>().Property(p => p.Email)
               .HasMaxLength(80)
               .IsUnicode(false);

            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Patient)
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<Patient>()
               .HasMany(p => p.Diagnoses)
               .WithOne(p => p.Patient)
               .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<Patient>()
               .HasMany(p => p.Visitations)
               .WithOne(p => p.Patient)
               .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<Visitation>().HasKey(k => new { k.VisitationId });
            modelBuilder.Entity<Visitation>().Property(p => p.Comments)
                .HasMaxLength(250)
                .IsUnicode();

            modelBuilder.Entity<Diagnose>().HasKey(k => new { k.DiagnoseId });
            modelBuilder.Entity<Diagnose>().Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();
            modelBuilder.Entity<Diagnose>().Property(p => p.Comments)
               .HasMaxLength(250)
               .IsUnicode();

            modelBuilder.Entity<Medicament>().HasKey(k => new { k.MedicamentId });
            modelBuilder.Entity<Medicament>().Property(p => p.Name)
                .HasMaxLength(50)
                .IsUnicode();

            modelBuilder.Entity<Medicament>()
                .HasMany(p => p.Prescriptions)
                .WithOne(p => p.Medicament)
                .HasForeignKey(p => p.MedicamentId);

            modelBuilder.Entity<PatientMedicament>().HasKey(k => new { k.PatientId, k.MedicamentId });
        }
    }
}
