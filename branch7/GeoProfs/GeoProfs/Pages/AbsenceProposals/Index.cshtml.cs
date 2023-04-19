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

namespace GeoProfs.Pages.AbsenceProposals
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

        public string ReasonSort { get; set; }
        public string StartDateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<AbsenceProposal> AbsenceProposals { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            StartDateSort = sortOrder == "StartDate" ? "startDate_desc" : "Date";
            ReasonSort = sortOrder == "Reason" ? "reason_desc" : "Reason";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<AbsenceProposal> proposalsIQ = from s in _context.AbsenceProposals
                                                      select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                proposalsIQ = proposalsIQ.Where(s => s.ReasonAbsence.Contains(searchString)
                                                || s.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "reason_desc":
                    proposalsIQ = proposalsIQ.OrderByDescending(s => s.ReasonAbsence);
                    break;
                case "Date":
                    proposalsIQ = proposalsIQ.OrderBy(s => s.StartAbsenceDate);
                    break;
                case "date_desc":
                    proposalsIQ = proposalsIQ.OrderByDescending(s => s.StartAbsenceDate);
                    break;
                default:
                    proposalsIQ = proposalsIQ.OrderBy(s => s.StartAbsenceDate);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 100);
            AbsenceProposals = await PaginatedList<AbsenceProposal>.CreateAsync(
                proposalsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}