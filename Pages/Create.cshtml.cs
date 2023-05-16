using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;

namespace PS6.Pages.History
{
    public class CreateModel : PageModel
    {
        private readonly PS6.Areas.YearDb.YearDbContext _context;

        public CreateModel(PS6.Areas.YearDb.YearDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public YearValidationResult YearValidationResult { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.YearValidationResult == null || YearValidationResult == null)
            {
                return Page();
            }

            _context.YearValidationResult.Add(YearValidationResult);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
