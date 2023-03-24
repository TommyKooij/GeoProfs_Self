using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;
using System.Globalization;

namespace GeoProfs.Pages.Calendars
{
    public class DeleteModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(GeoProfs.Data.GeoProfsContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public CalendarEvent CalendarEvent { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            CalendarEvent = await _context.CalendarEvents
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (CalendarEvent == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var calendar = await _context.CalendarEvents.FindAsync(id);

            if (calendar == null)
            {
                return NotFound();
            }

            try
            {
                _context.CalendarEvents.Remove(calendar);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
