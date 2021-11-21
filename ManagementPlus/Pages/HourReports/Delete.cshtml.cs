using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementPlus.Data;
using ManagementPlus.Models;

namespace ManagementPlus.Pages.HourReports
{
    public class DeleteModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public DeleteModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HourReport HourReport { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HourReport = await _context.HourReports
                .Include(h => h.Assignment).FirstOrDefaultAsync(m => m.Id == id);

            if (HourReport == null)
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

            HourReport = await _context.HourReports.FindAsync(id);

            if (HourReport != null)
            {
                _context.HourReports.Remove(HourReport);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
