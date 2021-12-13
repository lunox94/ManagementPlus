using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using ManagementPlus.ViewModels.Reports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ManagementPlus.Pages.Reports
{
    public class DailyReportModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public DailyReportModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        [Display(Name = "Report Date")]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }
        public IList<DailyReportGroupVM> DailyReport { get; set; }

        public void OnGet(int year, int month, int day)
        {
            ReportDate = new DateTime(year: year, month: month, day: day);

            DailyReport = GetDailyReport(ReportDate).ToList();
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

        private IEnumerable<DailyReportGroupVM> GetDailyReport(DateTime reportDate)
        {
            var groupByProjects = _context.HourReports
                .Where(r => r.DateOfIssue == reportDate)
                .Include(r => r.Assignment)
                .ThenInclude(a => a.Project)
                .Include(r => r.Assignment)
                .ThenInclude(a => a.IndividualContributor)
                .ToLookup(r => r.ProjectId);

            return groupByProjects.Select(g => new DailyReportGroupVM
            {
                Project = _mapper.Map<ProjectVM>(g.First().Assignment.Project),
                Items = GetGroupItems(g).ToList()
            });
        }

        private IEnumerable<DailyReportItemVM> GetGroupItems(IGrouping<Guid, HourReport> group)
        {
            var groupByICs = group
                .GroupBy(r => r.IndividualContributorId);

            var items = groupByICs.Select(g => new DailyReportItemVM
            {
                Developer = g.First().Assignment.IndividualContributor.FullName,
                Report = g.Sum(r => r.ReportedTime),
                Discount = g.Sum(r => r.DiscountTime),
                Reason = g.FirstOrDefault(r => !string.IsNullOrWhiteSpace(r.DiscountReason))?.DiscountReason
            }).ToList();

            items.ForEach(i => i.Worked = i.Report + i.Discount);

            return items;
        }
    }
}
