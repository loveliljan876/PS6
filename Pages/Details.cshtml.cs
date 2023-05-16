using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;

namespace PS6.Pages.History
{
    public class DetailsModel : PageModel
    {
        private readonly PS6.Areas.YearDb.YearDbContext _context;

        public DetailsModel(PS6.Areas.YearDb.YearDbContext context)
        {
            _context = context;
        }

      public YearValidationResult YearValidationResult { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.YearValidationResult == null)
            {
                return NotFound();
            }

            var yearvalidationresult = await _context.YearValidationResult.FirstOrDefaultAsync(m => m.Id == id);
            if (yearvalidationresult == null)
            {
                return NotFound();
            }
            else 
            {
                YearValidationResult = yearvalidationresult;
            }
            return Page();
        }
    }
}
