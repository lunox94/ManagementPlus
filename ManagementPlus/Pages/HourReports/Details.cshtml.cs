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
    public class DetailsModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public DetailsModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

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
    }
}
