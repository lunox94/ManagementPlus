using ManagementPlus.Models;
using Microsoft.EntityFrameworkCore;

namespace ManagementPlus.Data
{
    public static class IndividualContributorConfiguration
    {
        public static void ConfigureIndividualContributor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IndividualContributor>()
                .ToTable("IndividualContributor")
                .HasKey(ic => ic.Id);

            modelBuilder.Entity<IndividualContributor>()
                .Property(ic => ic.FullName)
                .IsRequired();
        }
    }
}
