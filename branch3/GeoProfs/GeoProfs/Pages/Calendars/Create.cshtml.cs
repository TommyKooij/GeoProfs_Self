using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfs.Data;
using GeoProfs.Models;
using System.Globalization;

namespace GeoProfs.Pages.Calendars
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
        public CalendarEvent CalendarEvent { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyCalendar = new CalendarEvent();

            if (await TryUpdateModelAsync<CalendarEvent>(
                emptyCalendar,
                "calendarEvent",   // Prefix for form value.
                s => s.Title, s => s.Description, s => s.StartDate, s => s.EndDate, s => s.Type))
            {
                _context.CalendarEvents.Add(emptyCalendar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
