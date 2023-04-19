using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using GeoProfs.Data;
using GeoProfs.Models;
using System.Globalization;

namespace GeoProfs.Pages.Calendars
{
    public class IndexModel : PageModel
    {
        private readonly GeoProfsContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(GeoProfsContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string StartDateSort { get; set; }
        public string EndDateSort { get; set; }
        public string TitleSort { get; set; }
        public string TypeSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<CalendarEvent> CalendarEvents { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = sortOrder == "Title" ? "title_desc" : "";
            StartDateSort = String.IsNullOrEmpty(sortOrder) ? "startDate_desc" : "StartDate";
            EndDateSort = sortOrder == "EndDate" ? "endDate_desc" : "EndDate";
            TypeSort = sortOrder == "Type" ? "type_desc" : "";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<CalendarEvent> calendarsIQ = from s in _context.CalendarEvents
                                                    select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                calendarsIQ = calendarsIQ.Where(s => s.StartDate.Equals(searchString));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    calendarsIQ = calendarsIQ.OrderByDescending(s => s.Title);
                    break;
                case "Start Date":
                    calendarsIQ = calendarsIQ.OrderBy(s => s.StartDate);
                    break;
                case "startDate_desc":
                    calendarsIQ = calendarsIQ.OrderByDescending(s => s.StartDate);
                    break;
                case "endDate_desc":
                    calendarsIQ = calendarsIQ.OrderByDescending(s => s.EndDate);
                    break;
                case "type_desc":
                    calendarsIQ = calendarsIQ.OrderByDescending(s => s.Type);
                    break;
                default:
                    calendarsIQ = calendarsIQ.OrderBy(s => s.StartDate);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 100);
            CalendarEvents = await PaginatedList<CalendarEvent>.CreateAsync(
                calendarsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}