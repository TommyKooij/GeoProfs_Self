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
using Ical.Net;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.Extensions.Logging;
using System.Text;

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

        public void GenerateICSFile(CalendarEvent calendarEvent)
        {
            //some variables for demo purposes
            DateTime DateStart = calendarEvent.StartDate;
            DateTime DateEnd = calendarEvent.EndDate;
            string Summary = calendarEvent.Title;
            string Description = calendarEvent.Description;
            string FileName = "CalendarItem";

            //create a new stringbuilder instance
            StringBuilder sb = new StringBuilder();

            //start the calendar item
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:stackoverflow.com");
            sb.AppendLine("CALSCALE:GREGORIAN");
            sb.AppendLine("METHOD:PUBLISH");

            //create a time zone if needed, TZID to be used in the event itself
            sb.AppendLine("BEGIN:VTIMEZONE");
            sb.AppendLine("TZID:Europe/Amsterdam");
            sb.AppendLine("BEGIN:STANDARD");
            sb.AppendLine("TZOFFSETTO:+0100");
            sb.AppendLine("TZOFFSETFROM:+0100");
            sb.AppendLine("END:STANDARD");
            sb.AppendLine("END:VTIMEZONE");

            //add the event
            sb.AppendLine("BEGIN:VEVENT");

            //with time zone specified
            sb.AppendLine("DTSTART;TZID=Europe/Amsterdam:" + DateStart.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND;TZID=Europe/Amsterdam:" + DateEnd.ToString("yyyyMMddTHHmm00"));
            //or without
            sb.AppendLine("DTSTART:" + DateStart.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND:" + DateEnd.ToString("yyyyMMddTHHmm00"));

            sb.AppendLine("SUMMARY:" + Summary + "");
            sb.AppendLine("DESCRIPTION:" + Description + "");
            sb.AppendLine("PRIORITY:3");
            sb.AppendLine("END:VEVENT");

            //end calendar item
            sb.AppendLine("END:VCALENDAR");

            //create a string from the stringbuilder
            string CalendarItem = sb.ToString();

            //send the calendar item to the browser
            Response.Headers.Clear();
            Response.Clear();
            Response.ContentType = "text/calendar";
            Response.Headers.Add("content-length", CalendarItem.Length.ToString());
            Response.Headers.Add("content-disposition", "attachment; filename=\"" + FileName + ".ics\"");
            Response.WriteAsync(CalendarItem);
        }
    }
}