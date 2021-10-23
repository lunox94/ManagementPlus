using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementPlus.Data;
using ManagementPlus.Models;

namespace ManagementPlus.Pages.IndividualContributors
{
    public class DetailsModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public DetailsModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        public IndividualContributor IndividualContributor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IndividualContributor = await _context.IndividualContributors.FirstOrDefaultAsync(m => m.Id == id);

            if (IndividualContributor == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
