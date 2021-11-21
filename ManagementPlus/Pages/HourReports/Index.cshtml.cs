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
    public class IndexModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public IndexModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        public IList<HourReport> HourReport { get;set; }

        public async Task OnGetAsync()
        {
            HourReport = await _context.HourReports
                .Include(h => h.Assignment).ToListAsync();
        }
    }
}
