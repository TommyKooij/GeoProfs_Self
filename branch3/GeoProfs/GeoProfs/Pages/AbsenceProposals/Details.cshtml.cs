using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.AbsenceProposals
{
    public class DetailsModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public DetailsModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public AbsenceProposal AbsenceProposal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AbsenceProposals == null)
            {
                return NotFound();
            }

            var proposal = await _context.AbsenceProposals
                .Include(s => s.Absences)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AbsenceProposalID == id);
            if (proposal == null)
            {
                return NotFound();
            }
            else
            {
                AbsenceProposal = proposal;
            }
            return Page();
        }
    }
}
