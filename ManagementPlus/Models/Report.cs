using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Models
{
    public class Report
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
