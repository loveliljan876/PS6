using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;

namespace PS6.Pages.History
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly PS6.Areas.YearDb.YearDbContext _context;

        public EditModel(PS6.Areas.YearDb.YearDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public YearValidationResult YearValidationResult { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.YearValidationResult == null)
            {
                return NotFound();
            }

            var yearvalidationresult =  await _context.YearValidationResult.FirstOrDefaultAsync(m => m.Id == id);
            if (yearvalidationresult == null)
            {
                return NotFound();
            }
            YearValidationResult = yearvalidationresult;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(YearValidationResult).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!YearValidationResultExists(YearValidationResult.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool YearValidationResultExists(int id)
        {
          return (_context.YearValidationResult?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
