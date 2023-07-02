using EF010.InitialMigration.Entities;
using MetigatorAcademyCFM_Api.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.InitialMigration.Data.Config
{
    public class ScheduleConfigration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(x => x.Title)
                .HasConversion(
                    x=> x.ToString(),
                    x=> (ScheduleEnum)Enum.Parse(typeof(ScheduleEnum), x)
                );

            builder.ToTable("Schedules");
            builder.HasData(LoadSchedules());
        }

        private static List<Schedule> LoadSchedules()
        {
            return new List<Schedule>
            {
                new Schedule { Id = 1, Title = ScheduleEnum.Daily, SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 2, Title = ScheduleEnum.DayAfterDay, SUN = true, MON = false, TUE = true, WED = false, THU = true, FRI = false, SAT = false },
                new Schedule { Id = 3, Title = ScheduleEnum.Twice_A_Week , SUN = false, MON = true, TUE = false, WED = true, THU = false, FRI = false, SAT = false },
                new Schedule { Id = 4, Title = ScheduleEnum.Weekend , SUN = false, MON = false, TUE = false, WED = false, THU = false, FRI = true, SAT = true },
                new Schedule { Id = 5, Title = ScheduleEnum.Compact , SUN = true, MON = true, TUE = true, WED = true, THU = true, FRI = true, SAT = true }
            };
        }
    }
}