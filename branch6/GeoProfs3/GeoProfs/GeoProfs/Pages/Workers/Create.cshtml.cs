using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfs.Areas.Identity.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Workers
{
    public class CreateModel : PageModel
    {
        private readonly GeoProfs.Areas.Identity.Data.GeoProfsContext _context;

        public CreateModel(GeoProfs.Areas.Identity.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Workers.Add(Worker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
