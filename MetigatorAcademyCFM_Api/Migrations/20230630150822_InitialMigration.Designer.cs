﻿// <auto-generated />
using System;
using EF010.InitialMigration.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MetigatorAcademyCFM_Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230630150822_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EF010.InitialMigration.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Price")
                        .HasPrecision(15, 2)
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("Id");

                    b.ToTable("Courses", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseName = "Mathmatics",
                            CreatedAt = new DateTime(2023, 6, 30, 15, 8, 22, 476, DateTimeKind.Utc).AddTicks(2625),
                            Price = 1000m
                        },
                        new
                        {
                            Id = 2,
                            CourseName = "Physics",
                            CreatedAt = new DateTime(2023, 6, 30, 15, 8, 22, 476, DateTimeKind.Utc).AddTicks(2631),
                            Price = 2000m
                        },
                        new
                        {
                            Id = 3,
                            CourseName = "Chemistry",
                            CreatedAt = new DateTime(2023, 6, 30, 15, 8, 22, 476, DateTimeKind.Utc).AddTicks(2633),
                            Price = 1500m
                        },
                        new
                        {
                            Id = 4,
                            CourseName = "Biology",
                            CreatedAt = new DateTime(2023, 6, 30, 15, 8, 22, 476, DateTimeKind.Utc).AddTicks(2635),
                            Price = 1200m
                        },
                        new
                        {
                            Id = 5,
                            CourseName = "CS-50",
                            CreatedAt = new DateTime(2023, 6, 30, 15, 8, 22, 476, DateTimeKind.Utc).AddTicks(2636),
                            Price = 3000m
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Enrollment", b =>
                {
                    b.Property<int>("SectionId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("SectionId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments", (string)null);

                    b.HasData(
                        new
                        {
                            SectionId = 6,
                            StudentId = 1
                        },
                        new
                        {
                            SectionId = 6,
                            StudentId = 2
                        },
                        new
                        {
                            SectionId = 7,
                            StudentId = 3
                        },
                        new
                        {
                            SectionId = 7,
                            StudentId = 4
                        },
                        new
                        {
                            SectionId = 8,
                            StudentId = 5
                        },
                        new
                        {
                            SectionId = 8,
                            StudentId = 6
                        },
                        new
                        {
                            SectionId = 9,
                            StudentId = 7
                        },
                        new
                        {
                            SectionId = 9,
                            StudentId = 8
                        },
                        new
                        {
                            SectionId = 10,
                            StudentId = 9
                        },
                        new
                        {
                            SectionId = 10,
                            StudentId = 10
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<int?>("OfficeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OfficeId")
                        .IsUnique()
                        .HasFilter("[OfficeId] IS NOT NULL");

                    b.ToTable("Instructors", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FName = "Ahmed",
                            LName = "Abdallah",
                            OfficeId = 1
                        },
                        new
                        {
                            Id = 2,
                            FName = "Yasmeen",
                            LName = "Mohamed",
                            OfficeId = 2
                        },
                        new
                        {
                            Id = 3,
                            FName = "Khalid",
                            LName = "Hassan",
                            OfficeId = 3
                        },
                        new
                        {
                            Id = 4,
                            FName = "Nadia",
                            LName = "Ali",
                            OfficeId = 4
                        },
                        new
                        {
                            Id = 5,
                            FName = "Omar",
                            LName = "Ibrahim",
                            OfficeId = 5
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Office", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("OfficeLocation")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("OfficeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Offices", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OfficeLocation = "building A",
                            OfficeName = "Off-05"
                        },
                        new
                        {
                            Id = 2,
                            OfficeLocation = "building B",
                            OfficeName = "Off-12"
                        },
                        new
                        {
                            Id = 3,
                            OfficeLocation = "Adminstration",
                            OfficeName = "Off-32"
                        },
                        new
                        {
                            Id = 4,
                            OfficeLocation = "IT Department",
                            OfficeName = "Off-44"
                        },
                        new
                        {
                            Id = 5,
                            OfficeLocation = "IT Department",
                            OfficeName = "Off-43"
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("FRI")
                        .HasColumnType("bit");

                    b.Property<bool>("MON")
                        .HasColumnType("bit");

                    b.Property<bool>("SAT")
                        .HasColumnType("bit");

                    b.Property<bool>("SUN")
                        .HasColumnType("bit");

                    b.Property<bool>("THU")
                        .HasColumnType("bit");

                    b.Property<bool>("TUE")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("WED")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Schedules", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FRI = false,
                            MON = true,
                            SAT = false,
                            SUN = true,
                            THU = true,
                            TUE = true,
                            Title = "Daily",
                            WED = true
                        },
                        new
                        {
                            Id = 2,
                            FRI = false,
                            MON = false,
                            SAT = false,
                            SUN = true,
                            THU = true,
                            TUE = true,
                            Title = "DayAfterDay",
                            WED = false
                        },
                        new
                        {
                            Id = 3,
                            FRI = false,
                            MON = true,
                            SAT = false,
                            SUN = false,
                            THU = false,
                            TUE = false,
                            Title = "Twice_A_Week",
                            WED = true
                        },
                        new
                        {
                            Id = 4,
                            FRI = true,
                            MON = false,
                            SAT = true,
                            SUN = false,
                            THU = false,
                            TUE = false,
                            Title = "Weekend",
                            WED = false
                        },
                        new
                        {
                            Id = 5,
                            FRI = true,
                            MON = true,
                            SAT = true,
                            SUN = true,
                            THU = true,
                            TUE = true,
                            Title = "Compact",
                            WED = true
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Section", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<int?>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("VARCHAR");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("InstructorId");

                    b.HasIndex("ScheduleId");

                    b.ToTable("Sections", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            EndTime = new TimeSpan(0, 10, 0, 0, 0),
                            InstructorId = 1,
                            ScheduleId = 1,
                            SectionName = "S_MA1",
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 1,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            InstructorId = 2,
                            ScheduleId = 3,
                            SectionName = "S_MA2",
                            StartTime = new TimeSpan(0, 14, 0, 0, 0)
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 2,
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            InstructorId = 1,
                            ScheduleId = 4,
                            SectionName = "S_PH1",
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 2,
                            EndTime = new TimeSpan(0, 12, 0, 0, 0),
                            InstructorId = 3,
                            ScheduleId = 1,
                            SectionName = "S_PH2",
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 3,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            InstructorId = 2,
                            ScheduleId = 1,
                            SectionName = "S_CH1",
                            StartTime = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 3,
                            EndTime = new TimeSpan(0, 10, 0, 0, 0),
                            InstructorId = 3,
                            ScheduleId = 2,
                            SectionName = "S_CH2",
                            StartTime = new TimeSpan(0, 8, 0, 0, 0)
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 4,
                            EndTime = new TimeSpan(0, 14, 0, 0, 0),
                            InstructorId = 4,
                            ScheduleId = 3,
                            SectionName = "S_BI1",
                            StartTime = new TimeSpan(0, 11, 0, 0, 0)
                        },
                        new
                        {
                            Id = 8,
                            CourseId = 4,
                            EndTime = new TimeSpan(0, 14, 0, 0, 0),
                            InstructorId = 5,
                            ScheduleId = 4,
                            SectionName = "S_BI2",
                            StartTime = new TimeSpan(0, 10, 0, 0, 0)
                        },
                        new
                        {
                            Id = 9,
                            CourseId = 5,
                            EndTime = new TimeSpan(0, 18, 0, 0, 0),
                            InstructorId = 4,
                            ScheduleId = 4,
                            SectionName = "S_CS1",
                            StartTime = new TimeSpan(0, 16, 0, 0, 0)
                        },
                        new
                        {
                            Id = 10,
                            CourseId = 5,
                            EndTime = new TimeSpan(0, 15, 0, 0, 0),
                            InstructorId = 5,
                            ScheduleId = 3,
                            SectionName = "S_CS2",
                            StartTime = new TimeSpan(0, 12, 0, 0, 0)
                        },
                        new
                        {
                            Id = 11,
                            CourseId = 5,
                            EndTime = new TimeSpan(0, 11, 0, 0, 0),
                            InstructorId = 4,
                            ScheduleId = 5,
                            SectionName = "S_CS3",
                            StartTime = new TimeSpan(0, 9, 0, 0, 0)
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Students", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FName = "Fatima",
                            LName = "Ali"
                        },
                        new
                        {
                            Id = 2,
                            FName = "Noor",
                            LName = "Saleh"
                        },
                        new
                        {
                            Id = 3,
                            FName = "Omar",
                            LName = "Youssef"
                        },
                        new
                        {
                            Id = 4,
                            FName = "Huda",
                            LName = "Ahmed"
                        },
                        new
                        {
                            Id = 5,
                            FName = "Amira",
                            LName = "Tariq"
                        },
                        new
                        {
                            Id = 6,
                            FName = "Zainab",
                            LName = "Ismail"
                        },
                        new
                        {
                            Id = 7,
                            FName = "Yousef",
                            LName = "Farid"
                        },
                        new
                        {
                            Id = 8,
                            FName = "Layla",
                            LName = "Mustafa"
                        },
                        new
                        {
                            Id = 9,
                            FName = "Mohammed",
                            LName = "Adel"
                        },
                        new
                        {
                            Id = 10,
                            FName = "Samira",
                            LName = "Nabil"
                        });
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Enrollment", b =>
                {
                    b.HasOne("EF010.InitialMigration.Entities.Section", "Section")
                        .WithMany("Enrollments")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF010.InitialMigration.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Section");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Instructor", b =>
                {
                    b.HasOne("EF010.InitialMigration.Entities.Office", "Office")
                        .WithOne("Instructor")
                        .HasForeignKey("EF010.InitialMigration.Entities.Instructor", "OfficeId");

                    b.Navigation("Office");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Section", b =>
                {
                    b.HasOne("EF010.InitialMigration.Entities.Course", "Course")
                        .WithMany("Sections")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EF010.InitialMigration.Entities.Instructor", "Instructor")
                        .WithMany("Sections")
                        .HasForeignKey("InstructorId");

                    b.HasOne("EF010.InitialMigration.Entities.Schedule", "Schedule")
                        .WithMany("Sections")
                        .HasForeignKey("ScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Course", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Instructor", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Office", b =>
                {
                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Schedule", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Section", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("EF010.InitialMigration.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
