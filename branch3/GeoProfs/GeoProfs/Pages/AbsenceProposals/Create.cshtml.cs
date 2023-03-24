using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GeoProfs.Data;
using GeoProfs.Models;
using System.Globalization;

namespace GeoProfs.Pages.AbsenceProposals
{
    public class CreateModel : PageModel
    {
        private readonly GeoProfs.Data.GeoProfsContext _context;

        public CreateModel(GeoProfs.Data.GeoProfsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public AbsenceProposal AbsenceProposal { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyProposal = new AbsenceProposal();

            if (await TryUpdateModelAsync<AbsenceProposal>(
                emptyProposal,
                "absenceProposal",   // Prefix for form value.
                s => s.Title, s => s.ReasonAbsence, s => s.Reasoning, s => s.StartAbsenceDate, s => s.EndAbsenceDate, s => s.Accepted))
            {
                _context.AbsenceProposals.Add(emptyProposal);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
