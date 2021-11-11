using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ManagementPlus.Data;
using ManagementPlus.Models;
using ManagementPlus.ViewModels;
using AutoMapper;

namespace ManagementPlus.Pages.Projects
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
        public ProjectToCreateVM Project { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var project = _mapper.Map<Project>(Project);

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
