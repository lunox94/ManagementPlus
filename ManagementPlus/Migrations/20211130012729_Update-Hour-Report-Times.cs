using Microsoft.EntityFrameworkCore.Migrations;

namespace ManagementPlus.Migrations
{
    public partial class UpdateHourReportTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "DiscountTime",
                table: "HourReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ReportedTime",
                table: "HourReport",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountTime",
                table: "HourReport");

            migrationBuilder.DropColumn(
                name: "ReportedTime",
                table: "HourReport");
        }
    }
}
