using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Areas.Identity.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.AbsenceProposals
{
    public class DeleteModel : PageModel
    {
        private readonly GeoProfs.Areas.Identity.Data.GeoProfsContext _context;

        public DeleteModel(GeoProfs.Areas.Identity.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AbsenceProposal AbsenceProposal { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AbsenceProposals == null)
            {
                return NotFound();
            }

            var absenceproposal = await _context.AbsenceProposals.FirstOrDefaultAsync(m => m.AbsenceProposalID == id);

            if (absenceproposal == null)
            {
                return NotFound();
            }
            else 
            {
                AbsenceProposal = absenceproposal;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AbsenceProposals == null)
            {
                return NotFound();
            }
            var absenceproposal = await _context.AbsenceProposals.FindAsync(id);

            if (absenceproposal != null)
            {
                AbsenceProposal = absenceproposal;
                _context.AbsenceProposals.Remove(AbsenceProposal);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
