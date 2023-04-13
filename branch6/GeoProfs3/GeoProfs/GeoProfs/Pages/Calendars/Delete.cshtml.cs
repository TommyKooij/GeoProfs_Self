using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Areas.Identity.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Calendars
{
    public class DeleteModel : PageModel
    {
        private readonly GeoProfs.Areas.Identity.Data.GeoProfsContext _context;

        public DeleteModel(GeoProfs.Areas.Identity.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public CalendarEvent CalendarEvent { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.CalendarEvents == null)
            {
                return NotFound();
            }

            var calendarevent = await _context.CalendarEvents.FirstOrDefaultAsync(m => m.ID == id);

            if (calendarevent == null)
            {
                return NotFound();
            }
            else 
            {
                CalendarEvent = calendarevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.CalendarEvents == null)
            {
                return NotFound();
            }
            var calendarevent = await _context.CalendarEvents.FindAsync(id);

            if (calendarevent != null)
            {
                CalendarEvent = calendarevent;
                _context.CalendarEvents.Remove(CalendarEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
