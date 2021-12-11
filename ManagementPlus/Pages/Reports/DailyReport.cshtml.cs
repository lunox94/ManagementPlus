using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ManagementPlus.Pages.Reports
{
    public class DailyReportModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Report Date")]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }

        public void OnGet(int year, int month, int day)
        {
            ReportDate = new DateTime(year: year, month: month, day: day);
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./DailyReport", routeValues: new
            {
                year = ReportDate.Year,
                month = ReportDate.Month,
                day = ReportDate.Day
            });
        }
    }
}
