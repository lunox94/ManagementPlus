using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.IndividualContributors
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

        public IndividualContributorVM IndividualContributor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualContributor = await _context.IndividualContributors.FirstOrDefaultAsync(m => m.Id == id);

            if (individualContributor == null)
            {
                return NotFound();
            }

            IndividualContributor = _mapper.Map<IndividualContributorVM>(individualContributor);

            return Page();
        }
    }
}
