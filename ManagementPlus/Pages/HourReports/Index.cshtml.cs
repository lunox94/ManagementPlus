using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.HourReports
{
    public class IndexModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public IndexModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<HourReport> HourReport { get;set; }
        [BindProperty]
        public ProjectVM Project { get; set; }
        [BindProperty]
        public IndividualContributorVM IndividualContributor { get; set; }
        [BindProperty]
        [Display(Name = "Report Date")]
        [DataType(DataType.Date)]
        public DateTime ReportDate { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Year { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Month { get; set; }
        [BindProperty(SupportsGet = true)]
        public int Day { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid projectId, Guid individualContributorId)
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            var individualContributor = await _context.IndividualContributors.FirstOrDefaultAsync(ic => ic.Id == individualContributorId);

            if (project == null || individualContributor == null)
            {
                return NotFound();
            }

            Project = _mapper.Map<ProjectVM>(project);
            IndividualContributor = _mapper.Map<IndividualContributorVM>(individualContributor);            

            ReportDate = new DateTime(year: Year, month: Month, day: Day);

            HourReport = await _context.HourReports
                .Where
                (
                    hr => hr.ProjectId == projectId
                    && hr.IndividualContributorId == individualContributorId
                    && hr.DateOfIssue == ReportDate
                )
                .ToListAsync();

            return Page();
        }

        public IActionResult OnPost()
        {
            return RedirectToPage("./Index", routeValues: new
            {
                projectId = Project.Id,
                individualContributorId = IndividualContributor.Id,
                year = ReportDate.Year,
                month = ReportDate.Month,
                day = ReportDate.Day
            });
        }
    }
}
