using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementPlus.Data;
using ManagementPlus.Models;

namespace ManagementPlus.Pages.Assignments
{
    public class DeleteModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public DeleteModel(ManagementPlus.Data.ManagementPlusContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignments.FindAsync(id);

            if (Assignment != null)
            {
                _context.Assignments.Remove(Assignment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
