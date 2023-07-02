using EF010.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.InitialMigration.Data.Config
{
    public class CourseConfigration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            //builder.Property(e => e.CourseName).HasMaxLength(255); // nvarchar(255)

            builder.Property(e => e.CourseName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(p => p.CreatedAt)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.Price).HasPrecision(15, 2);

            builder.ToTable("Courses");
            builder.HasData(LoadCourses());
        }

        private static List<Course> LoadCourses()
        {
            return new List<Course>
            {
                new Course { Id = 1, CourseName = "Mathmatics", Price = 1000m, CreatedAt = DateTime.UtcNow},
                new Course { Id = 2, CourseName = "Physics", Price = 2000m, CreatedAt = DateTime.UtcNow},
                new Course { Id = 3, CourseName = "Chemistry", Price = 1500m, CreatedAt = DateTime.UtcNow},
                new Course { Id = 4, CourseName = "Biology", Price = 1200m, CreatedAt = DateTime.UtcNow},
                new Course { Id = 5, CourseName = "CS-50", Price = 3000m, CreatedAt = DateTime.UtcNow},
            };
        }
    }
}