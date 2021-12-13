using System.Collections.Generic;

namespace ManagementPlus.ViewModels.Reports
{
    public class DailyReportGroupVM
    {
        public ProjectVM Project { get; set; }
        public IList<DailyReportItemVM> Items { get; set; }
    }
}
