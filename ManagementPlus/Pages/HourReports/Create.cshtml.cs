using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagementPlus.Data;
using ManagementPlus.Models;
using System.ComponentModel.DataAnnotations;
using ManagementPlus.ViewModels;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ManagementPlus.Pages.HourReports
{
    public class CreateModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public CreateModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public HourReportToCreateVM HourReport { get; set; }
        public ProjectVM Project { get; set; }
        public IndividualContributorVM IndividualContributor { get; set; }
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

            //Pre-fill data in hour report property
            HourReport = new HourReportToCreateVM
            {
                IndividualContributorId = individualContributorId,
                ProjectId = projectId,
                DateOfIssue = new DateTime(year: Year, month: Month, day: Day)
            };

            return Page();
        }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var hourReport = _mapper.Map<HourReport>(HourReport);
            _context.HourReports.Add(hourReport);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index", routeValues: new
            {
                projectId = HourReport.ProjectId,
                individualContributorId = HourReport.IndividualContributorId,
                year = HourReport.DateOfIssue.Year,
                month = HourReport.DateOfIssue.Month,
                day = HourReport.DateOfIssue.Day
            });
        }
    }
}
