using EF010.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.InitialMigration.Data.Config
{
    public class InstructorConfigration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.FName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.LName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(e => e.Office)
                .WithOne(e => e.Instructor)
                .HasForeignKey<Instructor>(e => e.OfficeId)
                .IsRequired(false);

            builder.ToTable("Instructors");
            builder.HasData(LoadInstructors());
        }

        private static List<Instructor> LoadInstructors()
        {
            return new List<Instructor>
            {
                new Instructor{Id = 1, FName = "Ahmed", LName = "Abdallah", OfficeId = 1},
                new Instructor{Id = 2, FName = "Yasmeen",  LName = "Mohamed", OfficeId = 2},
                new Instructor{Id = 3, FName = "Khalid",  LName = "Hassan", OfficeId = 3},
                new Instructor{Id = 4, FName = "Nadia",  LName = "Ali", OfficeId = 4},
                new Instructor{Id = 5, FName = "Omar", LName ="Ibrahim", OfficeId = 5}
            };
        }
    }
}