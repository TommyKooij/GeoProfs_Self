using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Workers
{
    public class CreateModel : RoleNameModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public CreateModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateRolesDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Worker Worker { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyWorker = new Worker();

            if (await TryUpdateModelAsync<Worker>(
                 emptyWorker,
                 "worker",   // Prefix for form value.
                 s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate, s => s.Role.RoleID, s => s.IsPresent))
            {
                _context.Workers.Add(emptyWorker);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select DepartmentID if TryUpdateModelAsync fails.
            PopulateRolesDropDownList(_context, emptyWorker.Role.RoleID);
            return Page();
        }
    }
}
