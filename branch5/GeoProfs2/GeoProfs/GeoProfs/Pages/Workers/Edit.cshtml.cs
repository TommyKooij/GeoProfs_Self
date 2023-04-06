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
    public class EditModel : RoleNameModel
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
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers
                .Include(c => c.Role).FirstOrDefaultAsync(m => m.ID == id);

            if (worker == null)
            {
                return NotFound();
            }
            // Select current DepartmentID.
            PopulateRolesDropDownList(_context, Worker.Role.RoleID);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workerToUpdate = await _context.Workers.FindAsync(id);

            if (workerToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Worker>(
                 workerToUpdate,
                 "worker",   // Prefix for form value.
                   s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate, s => s.Role.RoleID, s => s.IsPresent))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRolesDropDownList(_context, workerToUpdate.Role.RoleID);
            return Page();
        }

        private bool WorkerExists(int id)
        {
          return _context.Workers.Any(e => e.ID == id);
        }
    }
}
