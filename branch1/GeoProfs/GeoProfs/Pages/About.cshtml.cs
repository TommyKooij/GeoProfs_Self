using GeoProfs.Models.GeoProfsViewModels;
using GeoProfs.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoProfs.Models;

namespace GeoProfs.Pages
{
    public class AboutModel : PageModel
    {
        private readonly GeoProfsContext _context;

        public AboutModel(GeoProfsContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDatesGroup> Workers { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDatesGroup> data =
                from worker in _context.Workers
                group worker by worker.EnrollmentDate into dateGroup
                select new EnrollmentDatesGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    WorkerCount = dateGroup.Count()
                };

            Workers = await data.AsNoTracking().ToListAsync();
        }
    }
}