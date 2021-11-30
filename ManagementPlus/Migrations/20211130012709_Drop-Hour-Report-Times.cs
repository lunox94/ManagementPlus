using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementPlus.Migrations
{
    public partial class DropHourReportTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountTime",
                table: "HourReport");

            migrationBuilder.DropColumn(
                name: "ReportedTime",
                table: "HourReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "DiscountTime",
                table: "HourReport",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReportedTime",
                table: "HourReport",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
