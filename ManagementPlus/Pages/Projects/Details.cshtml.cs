using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.Projects
{
    public class DetailsModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public DetailsModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ProjectVM Project { get; set; }
        public IList<IndividualContributorVM> IndividualContributors { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(p => p.Assignments)
                .ThenInclude(a => a.IndividualContributor)
                .FirstOrDefaultAsync(p => p.Id == id);            

            if (project == null)
            {
                return NotFound();
            }

            var individualContributors = project.Assignments.Select(a => a.IndividualContributor);

            Project = _mapper.Map<ProjectVM>(project);

            IndividualContributors = _mapper.Map<IList<IndividualContributorVM>>(individualContributors);

            return Page();
        }
    }
}
