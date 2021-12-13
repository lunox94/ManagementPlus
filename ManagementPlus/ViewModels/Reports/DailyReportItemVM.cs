using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels.Reports
{
    public class DailyReportItemVM
    {
        public string Developer { get; set; }
        [UIHint("TimeSpanTicks")]
        public long Worked { get; set; }
        [UIHint("TimeSpanTicks")]
        public long Report { get; set; }
        [UIHint("TimeSpanTicks")]
        public long Discount { get; set; }
        public string Reason { get; set; }
    }
}
