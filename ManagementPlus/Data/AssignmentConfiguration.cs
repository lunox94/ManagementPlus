using ManagementPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementPlus.Data
{
    public static class AssignmentConfiguration
    {
        public static void ConfigureAssignment(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .ToTable("Assignment")
                .HasKey(a => new { a.IndividualContributorId, a.ProjectId });

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.IndividualContributor)
                .WithMany(ic => ic.Assignments)
                .HasForeignKey(a => a.IndividualContributorId);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.Project)
                .WithMany(p => p.Assignments)
                .HasForeignKey(a => a.ProjectId);
        }
    }
}
