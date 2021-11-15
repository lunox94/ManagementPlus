using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.IndividualContributors
{
    public class EditModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public EditModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [BindProperty]
        public IndividualContributorToEditVM IndividualContributor { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var individualContributor = await _context.IndividualContributors.FirstOrDefaultAsync(m => m.Id == id);

            if (individualContributor == null)
            {
                return NotFound();
            }

            IndividualContributor = _mapper.Map<IndividualContributorToEditVM>(individualContributor);

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

            var individualContributor = _mapper.Map<IndividualContributor>(IndividualContributor);

            _context.Attach(individualContributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IndividualContributorExists(individualContributor.Id))
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
