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

namespace GeoProfs.Pages.Employees
{
    public class EditModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public EditModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Employee Employee { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees.FindAsync(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var employeeToUpdate = await _context.Employees.FindAsync(id);

            if (employeeToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Employee>(
                employeeToUpdate,
                "employee",
                s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate, s => s.Role, s => s.Mail, s => s.IsPresent, s => s.maxAbsenceDays, s => s.totalSickDays, s => s.totalOffDays))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool EmployeesExists(int id)
        {
            return _context.Employees.Any(e => e.ID == id);
        }
    }
}