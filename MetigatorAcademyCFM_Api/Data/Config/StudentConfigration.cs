using EF010.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.InitialMigration.Data.Config
{
    public class StudentConfigration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
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

            builder.ToTable("Students");
            builder.HasData(LoadStudents());
        }

        private static List<Student> LoadStudents()
        {
            return new List<Student>
            {
                 new Student() { Id = 1, FName = "Fatima", LName = "Ali" },
                 new Student() { Id = 2, FName = "Noor" , LName = "Saleh" },
                 new Student() { Id = 3, FName = "Omar" , LName = "Youssef" },
                 new Student() { Id = 4, FName = "Huda" , LName = "Ahmed" },
                 new Student() { Id = 5, FName = "Amira" , LName = "Tariq" },
                 new Student() { Id = 6, FName = "Zainab" , LName = "Ismail" },
                 new Student() { Id = 7, FName = "Yousef" , LName = "Farid" },
                 new Student() { Id = 8, FName = "Layla" , LName = "Mustafa" },
                 new Student() { Id = 9, FName = "Mohammed" , LName = "Adel" },
                 new Student() { Id = 10, FName = "Samira" , LName = "Nabil" }
            };
        }
    }
}