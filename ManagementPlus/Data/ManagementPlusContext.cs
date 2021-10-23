using ManagementPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementPlus.Data
{
    public class ManagementPlusContext : DbContext
    {
        public DbSet<IndividualContributor> IndividualContributors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<HourReport> HourReports { get; set; }

        public ManagementPlusContext(DbContextOptions<ManagementPlusContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureIndividualContributor();
            modelBuilder.ConfigureProject();
            modelBuilder.ConfigureAssignment();
            modelBuilder.ConfigureHourReport();
        }


    }
}
