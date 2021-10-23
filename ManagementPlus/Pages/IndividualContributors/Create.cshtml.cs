using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagementPlus.Data;
using ManagementPlus.Models;

namespace ManagementPlus.Pages.IndividualContributors
{
    public class CreateModel : PageModel
    {
        private readonly ManagementPlus.Data.ManagementPlusContext _context;

        public CreateModel(ManagementPlus.Data.ManagementPlusContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IndividualContributor IndividualContributor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.IndividualContributors.Add(IndividualContributor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
