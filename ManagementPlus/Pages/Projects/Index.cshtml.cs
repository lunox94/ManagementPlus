using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using AutoMapper;

namespace ManagementPlus.Pages.Projects
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

        public IList<ProjectVM> Projects { get;set; }

        public async Task OnGetAsync()
        {
            Projects = _mapper.Map<IList<ProjectVM>>(await _context.Projects.ToListAsync());
        }
    }
}
