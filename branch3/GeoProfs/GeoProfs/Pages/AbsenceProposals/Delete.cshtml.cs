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
    public class DeleteModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(GeoProfs.Data.GeoProfsContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public AbsenceProposal AbsenceProposal { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            AbsenceProposal = await _context.AbsenceProposals
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.AbsenceProposalID == id);

            if (AbsenceProposal == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proposal = await _context.AbsenceProposals.FindAsync(id);

            if (proposal == null)
            {
                return NotFound();
            }

            try
            {
                _context.AbsenceProposals.Remove(proposal);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
