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
    public class IndexModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public IndexModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignment { get;set; }

        public async Task OnGetAsync()
        {
            Assignment = await _context.Assignments
                .Include(a => a.IndividualContributor)
                .Include(a => a.Project).ToListAsync();
        }
    }
}
