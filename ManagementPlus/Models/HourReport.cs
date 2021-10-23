using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.Models
{
    public class HourReport
    {
        public Guid Id { get; set; }
        public Guid IndividualContributorId { get; set; }
        public Guid ProjectId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }
        public TimeSpan ReportedTime { get; set; }
        public string LinkToTicketManager { get; set; }
        public string Description { get; set; }
        public TimeSpan DiscountTime { get; set; }
        public string DiscountReason { get; set; }

        public Assignment Assignment;
    }
}
