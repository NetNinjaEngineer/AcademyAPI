using EF010.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.InitialMigration.Data.Config
{
    public class SectionConfigration : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.SectionName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasOne(e => e.Course)
                .WithMany(e => e.Sections)
                .HasForeignKey(e => e.CourseId)
                .IsRequired(false);

            builder.HasOne(e => e.Instructor)
                .WithMany(e => e.Sections)
                .HasForeignKey(e => e.InstructorId)
                .IsRequired(false);

            builder.HasOne(x => x.Schedule)
                .WithMany(x => x.Sections)
                .HasForeignKey(x=> x.ScheduleId)
                .IsRequired();

            builder.HasMany(e => e.Students)
                .WithMany(e => e.Sections)
                .UsingEntity<Enrollment>();

            builder.ToTable("Sections");
            builder.HasData(LoadSections());
        }

        private static List<Section> LoadSections()
        {
            return new List<Section>
            {
                new Section { Id = 1, SectionName = "S_MA1", ScheduleId = 1,   CourseId = 1, InstructorId = 1, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00")},
                new Section { Id = 2, SectionName = "S_MA2", ScheduleId = 3,   CourseId = 1, InstructorId = 2, StartTime = TimeSpan.Parse("14:00:00"), EndTime = TimeSpan.Parse("18:00:00")},
                new Section { Id = 3, SectionName = "S_PH1", ScheduleId = 4,   CourseId = 2, InstructorId = 1, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("15:00:00")},
                new Section { Id = 4, SectionName = "S_PH2", ScheduleId = 1,   CourseId = 2, InstructorId = 3, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("12:00:00")},
                new Section { Id = 5, SectionName = "S_CH1", ScheduleId = 1,   CourseId = 3, InstructorId =2 , StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00")},
                new Section { Id = 6, SectionName = "S_CH2", ScheduleId = 2,   CourseId = 3, InstructorId = 3, StartTime = TimeSpan.Parse("08:00:00"), EndTime = TimeSpan.Parse("10:00:00")},
                new Section { Id = 7, SectionName = "S_BI1", ScheduleId = 3,   CourseId = 4, InstructorId = 4, StartTime = TimeSpan.Parse("11:00:00"), EndTime = TimeSpan.Parse("14:00:00")},
                new Section { Id = 8, SectionName = "S_BI2", ScheduleId = 4,   CourseId = 4, InstructorId = 5, StartTime = TimeSpan.Parse("10:00:00"), EndTime = TimeSpan.Parse("14:00:00")},
                new Section { Id = 9, SectionName = "S_CS1", ScheduleId = 4,   CourseId = 5, InstructorId = 4, StartTime = TimeSpan.Parse("16:00:00"), EndTime = TimeSpan.Parse("18:00:00")},
                new Section { Id = 10, SectionName = "S_CS2",ScheduleId = 3,   CourseId = 5, InstructorId =5, StartTime = TimeSpan.Parse("12:00:00"), EndTime = TimeSpan.Parse("15:00:00")},
                new Section { Id = 11, SectionName = "S_CS3",ScheduleId = 5,   CourseId = 5, InstructorId =4, StartTime = TimeSpan.Parse("09:00:00"), EndTime = TimeSpan.Parse("11:00:00")}
            };
        }
    }
}