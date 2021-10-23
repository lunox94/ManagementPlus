using ManagementPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementPlus.Data
{
    public static class HourReportConfiguration
    {
        public static void ConfigureHourReport(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HourReport>()
                .ToTable("HourReport")
                .HasKey(r => r.Id);

            modelBuilder.Entity<HourReport>()
                .HasOne(r => r.Assignment)
                .WithMany(a => a.HourReports)
                .HasForeignKey(r => new { r.IndividualContributorId, r.ProjectId });
        }
    }
}
