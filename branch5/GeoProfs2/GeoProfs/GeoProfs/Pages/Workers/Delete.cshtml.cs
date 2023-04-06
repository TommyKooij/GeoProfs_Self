using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Workers
{
    public class DeleteModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public DeleteModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers
                .AsNoTracking()
                .Include(c => c.Role)
                .FirstOrDefaultAsync(m => m.ID == id);

            var worker = await _context.Workers.FirstOrDefaultAsync(m => m.ID == id);

            if (Worker == null)
            {
                return NotFound();
            }
            else 
            {
                worker = Worker;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }
            var worker = await _context.Workers.FindAsync(id);

            if (worker != null)
            {
                Worker = worker;
                _context.Workers.Remove(Worker);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
