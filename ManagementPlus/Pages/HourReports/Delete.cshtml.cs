using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.HourReports
{
    public class DeleteModel : PageModel
    {
        private readonly ManagementPlusContext _context;

        public DeleteModel(ManagementPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HourReportVM HourReport { get; set; }
        public ProjectVM Project { get; set; }
        public IndividualContributorVM IndividualContributor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id, [FromServices] IMapper mapper)
        {
            var hourReport = await _context.HourReports
                .Include(h => h.Assignment)
                .ThenInclude(a => a.Project)
                .Include(h => h.Assignment)
                .ThenInclude(a => a.IndividualContributor)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (hourReport == null)
            {
                return NotFound();
            }

            HourReport = mapper.Map<HourReportVM>(hourReport);
            Project = mapper.Map<ProjectVM>(hourReport.Assignment.Project);
            IndividualContributor = mapper.Map<IndividualContributorVM>(hourReport.Assignment.IndividualContributor);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            var hourReport = await _context.HourReports.FindAsync(id);

            if (hourReport != null)
            {
                _context.HourReports.Remove(hourReport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index", routeValues: new
            {
                projectId = hourReport.ProjectId,
                individualContributorId = hourReport.IndividualContributorId,
                year = hourReport.DateOfIssue.Year,
                month = hourReport.DateOfIssue.Month,
                day = hourReport.DateOfIssue.Day
            });
        }
    }
}
