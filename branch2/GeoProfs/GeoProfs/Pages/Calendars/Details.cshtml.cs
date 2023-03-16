using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Calendars
{
    public class DetailsModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public DetailsModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

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
    }
}
