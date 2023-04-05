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
    public class IndexModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public IndexModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IList<CalendarEvent> CalendarEvent { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.CalendarEvents != null)
            {
                CalendarEvent = await _context.CalendarEvents.ToListAsync();
            }
        }
    }
}
