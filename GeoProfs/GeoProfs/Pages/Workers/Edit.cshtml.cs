using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Workers
{
    public class EditModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public EditModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Worker Worker { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Worker = await _context.Workers.FindAsync(id);

            if (Worker == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var workerToUpdate = await _context.Workers.FindAsync(id);

            if (workerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Worker>(
                workerToUpdate,
                "worker",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool WorkerExists(int id)
        {
          return _context.Workers.Any(e => e.ID == id);
        }
    }
}
