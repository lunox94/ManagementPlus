using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.IndividualContributors
{
    public class CreateModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public CreateModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public IndividualContributorToCreateVM IndividualContributor { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var individualContributor = _mapper.Map<IndividualContributor>(IndividualContributor);

            _context.IndividualContributors.Add(individualContributor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
