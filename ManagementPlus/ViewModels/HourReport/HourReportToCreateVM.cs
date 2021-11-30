using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels
{
    public class HourReportToCreateVM
    {
        public Guid IndividualContributorId { get; set; }
        public Guid ProjectId { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }
        [Required]
        [RegularExpression(@"^([1-9][0-9]*)(:[0-5][0-9])?$")]
        [Display(Name = "Reported Time")]
        public string ReportedTime { get; set; }
        [Display(Name = "Link To Ticket Manager")]
        public string LinkToTicketManager { get; set; }
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^([1-9][0-9]*)(:[0-5][0-9])?$")]
        [Display(Name = "Discount Time")]
        public string DiscountTime { get; set; }
        [Display(Name = "Discount Reason")]
        public string DiscountReason { get; set; }
    }
}
