using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementPlus.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IndividualContributor",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    BaseSalary = table.Column<int>(type: "int", nullable: false),
                    HiringDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Province = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndividualContributor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HoursLimit = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Assignment",
                columns: table => new
                {
                    IndividualContributorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfFirstAssignment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfLastAssignment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignment", x => new { x.IndividualContributorId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_Assignment_IndividualContributor_IndividualContributorId",
                        column: x => x.IndividualContributorId,
                        principalTable: "IndividualContributor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignment_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HourReport",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IndividualContributorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateOfIssue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportedTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LinkToTicketManager = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    DiscountReason = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HourReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HourReport_Assignment_IndividualContributorId_ProjectId",
                        columns: x => new { x.IndividualContributorId, x.ProjectId },
                        principalTable: "Assignment",
                        principalColumns: new[] { "IndividualContributorId", "ProjectId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Assignment_ProjectId",
                table: "Assignment",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_HourReport_IndividualContributorId_ProjectId",
                table: "HourReport",
                columns: new[] { "IndividualContributorId", "ProjectId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HourReport");

            migrationBuilder.DropTable(
                name: "Assignment");

            migrationBuilder.DropTable(
                name: "IndividualContributor");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
