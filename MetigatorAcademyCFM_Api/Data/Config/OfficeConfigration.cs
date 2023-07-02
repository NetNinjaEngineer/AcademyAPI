using EF010.InitialMigration.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EF010.InitialMigration.Data.Config
{
    public class OfficeConfigration : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedNever();

            builder.Property(e => e.OfficeName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.OfficeLocation)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("Offices");
            builder.HasData(LoadOffices());
        }

        private static List<Office> LoadOffices()
        {
            return new List<Office>
            {
                new Office{Id = 1, OfficeName = "Off-05", OfficeLocation = "building A"},
                new Office{Id = 2, OfficeName = "Off-12", OfficeLocation = "building B"},
                new Office{Id = 3, OfficeName = "Off-32", OfficeLocation = "Adminstration"},
                new Office{Id = 4, OfficeName = "Off-44", OfficeLocation = "IT Department"},
                new Office{Id = 5, OfficeName = "Off-43", OfficeLocation = "IT Department"}
            };
        }
    }
}