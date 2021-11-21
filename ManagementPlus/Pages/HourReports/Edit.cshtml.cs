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

namespace ManagementPlus.Pages.HourReports
{
    public class EditModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public EditModel(ManagementPlus.Data.ManagementPlusContext context)
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
           ViewData["IndividualContributorId"] = new SelectList(_context.Assignments, "IndividualContributorId", "IndividualContributorId");
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

            _context.Attach(HourReport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HourReportExists(HourReport.Id))
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

        private bool HourReportExists(Guid id)
        {
            return _context.HourReports.Any(e => e.Id == id);
        }
    }
}
