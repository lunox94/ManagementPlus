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

namespace ManagementPlus.Pages.IndividualContributors
{
    public class EditModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public EditModel(ManagementPlus.Data.ManagementPlusContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(IndividualContributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualContributorExists(IndividualContributor.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IndividualContributorExists(Guid id)
        {
            return _context.IndividualContributors.Any(e => e.Id == id);
        }
    }
}
