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
    public class DetailsModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public DetailsModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

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
    }
}
