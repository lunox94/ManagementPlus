using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public ProjectVM Project { get; set; }
        public IndividualContributorVM IndividualContributor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? projectId, Guid? individualContributorId)
        {
            if (projectId == null || individualContributorId == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            var individualContributor = await _context.IndividualContributors.FirstOrDefaultAsync(ic => ic.Id == individualContributorId);

            if (project == null || individualContributor == null)
            {
                return NotFound();
            }

            Project = _mapper.Map<ProjectVM>(project);
            IndividualContributor = _mapper.Map<IndividualContributorVM>(individualContributor);

            HourReport = await _context.HourReports
                .Where(hr => hr.ProjectId == projectId && hr.IndividualContributorId == individualContributorId)
                .ToListAsync();
            
            return Page();
        }
    }
}
