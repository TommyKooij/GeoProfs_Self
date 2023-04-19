using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GeoProfs.Data;
using GeoProfs.Models;

namespace GeoProfs.Pages.AbsenceProposals
{
    public class EditModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public EditModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public AbsenceProposal AbsenceProposal { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AbsenceProposal = await _context.AbsenceProposals.FindAsync(id);

            if (AbsenceProposal == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var proposalToUpdate = await _context.AbsenceProposals.FindAsync(id);

            if (proposalToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<AbsenceProposal>(
                proposalToUpdate,
                "absenceProposal",
                s => s.Title, s => s.ReasonAbsence, s => s.Reasoning, s => s.StartAbsenceDate, s => s.EndAbsenceDate, s => s.Accepted, s => s.Rejected))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool ProposalExists(int id)
        {
            return _context.AbsenceProposals.Any(e => e.AbsenceProposalID == id);
        }
    }
}