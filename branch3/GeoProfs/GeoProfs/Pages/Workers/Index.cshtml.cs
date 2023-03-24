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

namespace GeoProfs.Pages.Workers
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

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string RoleSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Worker> Workers { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            RoleSort = sortOrder == "Role" ? "role_desc" : "Role";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Worker> workersIQ = from s in _context.Workers
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                workersIQ = workersIQ.Where(s => s.LastName.Contains(searchString)
                                       || s.FirstMidName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    workersIQ = workersIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    workersIQ = workersIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    workersIQ = workersIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "role_desc":
                    workersIQ = workersIQ.OrderBy(s => s.Role);
                    break;
                default:
                    workersIQ = workersIQ.OrderBy(s => s.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 100);
            Workers = await PaginatedList<Worker>.CreateAsync(
                workersIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
