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

namespace ManagementPlus.Pages.Assignments
{
    public class EditModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public EditModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignments
                .Include(a => a.IndividualContributor)
                .Include(a => a.Project).FirstOrDefaultAsync(m => m.IndividualContributorId == id);

            if (Assignment == null)
            {
                return NotFound();
            }
           ViewData["IndividualContributorId"] = new SelectList(_context.IndividualContributors, "Id", "FullName");
           ViewData["ProjectId"] = new SelectList(_context.Projects, "Id", "Name");
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

            _context.Attach(Assignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignmentExists(Assignment.IndividualContributorId))
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

        private bool AssignmentExists(Guid id)
        {
            return _context.Assignments.Any(e => e.IndividualContributorId == id);
        }
    }
}
