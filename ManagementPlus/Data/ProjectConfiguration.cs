using ManagementPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementPlus.Data
{
    public static class ProjectConfiguration
    {
        public static void ConfigureProject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .ToTable("Project")
                .HasKey(p => p.Id);
        }
    }
}
