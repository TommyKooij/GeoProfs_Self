using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Employees
{
    public class CreateModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public CreateModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyEmployee = new Employee();

            if (await TryUpdateModelAsync<Employee>(
                emptyEmployee,
                "employee",   // Prefix for form value.
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate, s => s.Role, s => s.Mail, s => s.IsPresent, s => s.maxAbsenceDays, s => s.totalSickDays, s => s.totalOffDays))
            {
                _context.Employees.Add(emptyEmployee);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}