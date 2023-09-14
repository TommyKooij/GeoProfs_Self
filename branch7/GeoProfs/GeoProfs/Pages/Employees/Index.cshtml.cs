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

namespace GeoProfs.Pages.Employees
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

        public string FirstNameSort { get; set; }
        public string LastNameSort { get; set; }
        public string DateSort { get; set; }
        public string RoleSort { get; set; }
        public string TeamSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Employee> Employees { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            FirstNameSort = String.IsNullOrEmpty(sortOrder) ? "firstName_desc" : "";
            LastNameSort = String.IsNullOrEmpty(sortOrder) ? "lastName_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            RoleSort = sortOrder == "Role" ? "role_desc" : "Role";
            TeamSort = sortOrder == "Team" ? "team_desc" : "Team";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Employee> employeesIQ = from s in _context.Employees
                                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                employeesIQ = employeesIQ.Where(s => s.FirstMidName.Contains(searchString)
                                       || s.LastName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "firstName_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.FirstMidName);
                    break;
                case "lastName_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    employeesIQ = employeesIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    employeesIQ = employeesIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                case "role_desc":
                    employeesIQ = employeesIQ.OrderBy(s => s.Role);
                    break;
                case "team_desc":
                    employeesIQ = employeesIQ.OrderBy(s => s.Team);
                    break;
                default:
                    employeesIQ = employeesIQ.OrderBy(s => s.LastName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 100);
            Employees = await PaginatedList<Employee>.CreateAsync(
                employeesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}