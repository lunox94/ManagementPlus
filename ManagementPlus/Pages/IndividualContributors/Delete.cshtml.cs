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
    public class DeleteModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public DeleteModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IndividualContributor = await _context.IndividualContributors.FindAsync(id);

            if (IndividualContributor != null)
            {
                _context.IndividualContributors.Remove(IndividualContributor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
