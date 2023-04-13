﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly GeoProfs.Areas.Identity.Data.GeoProfsContext _context;

        public DetailsModel(GeoProfs.Areas.Identity.Data.GeoProfsContext context)
        {
            _context = context;
        }

      public Worker Worker { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Workers == null)
            {
                return NotFound();
            }

            var worker = await _context.Workers.FirstOrDefaultAsync(m => m.ID == id);
            if (worker == null)
            {
                return NotFound();
            }
            else 
            {
                Worker = worker;
            }
            return Page();
        }
    }
}
