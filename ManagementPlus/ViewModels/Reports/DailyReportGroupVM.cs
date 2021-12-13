using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ManagementPlus.ViewModels.Reports
{
    public class DailyReportGroupVM
    {
        public ProjectVM Project { get; set; }
        public IList<DailyReportItemVM> Items { get; set; }
        [UIHint("TimeSpanTicks")]
        public long TotalWorked { get; set; }
        [UIHint("TimeSpanTicks")]
        public long TotalReport { get; set; }
        [UIHint("TimeSpanTicks")]
        public long TotalDiscount { get; set; }
    }
}
