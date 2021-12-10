using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using AutoMapper;

namespace ManagementPlus.Pages.HourReports
{
    public class EditModel : PageModel
    {
        private readonly ManagementPlusContext _context;

        public EditModel(ManagementPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HourReportToEditVM HourReport { get; set; }
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

            HourReport = mapper.Map<HourReportToEditVM>(hourReport);
            Project = mapper.Map<ProjectVM>(hourReport.Assignment.Project);
            IndividualContributor = mapper.Map<IndividualContributorVM>(hourReport.Assignment.IndividualContributor);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync([FromServices] IMapper mapper)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var hourReport = mapper.Map<HourReport>(HourReport);
            _context.Attach(hourReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourReportExists(HourReport.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index", routeValues: new
            {
                projectId = HourReport.ProjectId,
                individualContributorId = HourReport.IndividualContributorId,
                year = HourReport.DateOfIssue.Year,
                month = HourReport.DateOfIssue.Month,
                day = HourReport.DateOfIssue.Day
            });
        }

        private bool HourReportExists(Guid id)
        {
            return _context.HourReports.Any(e => e.Id == id);
        }
    }
}
