using System;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels
{
    public class HourReportVM
    {
        public Guid Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfIssue { get; set; }
        [Display(Name = "Reported Time")]
        public string ReportedTime { get; set; }
        [Display(Name = "Link To Ticket Manager")]
        public string LinkToTicketManager { get; set; }
        public string Description { get; set; }
        [Display(Name = "Discount Time")]
        public string DiscountTime { get; set; }
        [Display(Name = "Discount Reason")]
        public string DiscountReason { get; set; }
    }
}
