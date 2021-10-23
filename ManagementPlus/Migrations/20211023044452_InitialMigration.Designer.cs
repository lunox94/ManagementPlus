﻿// <auto-generated />
using System;
using ManagementPlus.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ManagementPlus.Migrations
{
    [DbContext(typeof(ManagementPlusContext))]
    [Migration("20211023044452_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ManagementPlus.Models.Assignment", b =>
                {
                    b.Property<Guid>("IndividualContributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfFirstAssignment")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfLastAssignment")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("IndividualContributorId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Assignment");
                });

            modelBuilder.Entity("ManagementPlus.Models.HourReport", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfIssue")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiscountReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("DiscountTime")
                        .HasColumnType("time");

                    b.Property<Guid>("IndividualContributorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LinkToTicketManager")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("ReportedTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("IndividualContributorId", "ProjectId");

                    b.ToTable("HourReport");
                });

            modelBuilder.Entity("ManagementPlus.Models.IndividualContributor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("BaseSalary")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("HiringDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Province")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IndividualContributor");
                });

            modelBuilder.Entity("ManagementPlus.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<TimeSpan>("HoursLimit")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("ManagementPlus.Models.Assignment", b =>
                {
                    b.HasOne("ManagementPlus.Models.IndividualContributor", "IndividualContributor")
                        .WithMany("Assignments")
                        .HasForeignKey("IndividualContributorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ManagementPlus.Models.Project", "Project")
                        .WithMany("Assignments")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IndividualContributor");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("ManagementPlus.Models.HourReport", b =>
                {
                    b.HasOne("ManagementPlus.Models.Assignment", "Assignment")
                        .WithMany("HourReports")
                        .HasForeignKey("IndividualContributorId", "ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Assignment");
                });

            modelBuilder.Entity("ManagementPlus.Models.Assignment", b =>
                {
                    b.Navigation("HourReports");
                });

            modelBuilder.Entity("ManagementPlus.Models.IndividualContributor", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("ManagementPlus.Models.Project", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
