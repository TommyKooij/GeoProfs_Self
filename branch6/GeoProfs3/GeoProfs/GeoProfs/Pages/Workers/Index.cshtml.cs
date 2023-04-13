using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Areas.Identity.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.Workers
{
    public class IndexModel : PageModel
    {
        private readonly GeoProfs.Areas.Identity.Data.GeoProfsContext _context;

        public IndexModel(GeoProfs.Areas.Identity.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IList<Worker> Worker { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Workers != null)
            {
                Worker = await _context.Workers.ToListAsync();
            }
        }
    }
}
