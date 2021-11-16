using AutoMapper;
using ManagementPlus.Data;
using ManagementPlus.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManagementPlus.Pages.IndividualContributors
{
    public class IndexModel : PageModel
    {
        private readonly ManagementPlusContext _context;
        private readonly IMapper _mapper;

        public IndexModel(ManagementPlusContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IList<IndividualContributorVM> IndividualContributors { get;set; }

        public async Task OnGetAsync()
        {
            IndividualContributors = 
                _mapper.Map<IList<IndividualContributorVM>>(await _context.IndividualContributors.ToListAsync());
        }
    }
}
