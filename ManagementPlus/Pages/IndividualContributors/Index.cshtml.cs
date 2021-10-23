using ManagementPlus.Data;
using ManagementPlus.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.IndividualContributors
{
    public class IndexModel : PageModel
    {
        private readonly ManagementPlusContext _context;

        public IndexModel(ManagementPlusContext context)
        {
            _context = context;
        }

        public IList<IndividualContributor> IndividualContributor { get;set; }

        public async Task OnGetAsync()
        {
            IndividualContributor = await _context.IndividualContributors.ToListAsync();
        }
    }
}
