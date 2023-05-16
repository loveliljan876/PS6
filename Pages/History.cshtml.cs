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
    public class IndexModel : PageModel
    {
        private readonly PS6.Areas.YearDb.YearDbContext _context;

        public IndexModel(PS6.Areas.YearDb.YearDbContext context)
        {
            _context = context;
        }

        public IList<YearValidationResult> YearValidationResult { get;set; } = default!;

        public async Task OnGetAsync(int pageIndex = 1)
        {
            if (_context.YearValidationResult != null)
            {
                YearValidationResult = await PaginatedList<YearValidationResult>.CreateAsync(
                _context.YearValidationResult.AsNoTracking(), pageIndex, 20);
            }
        }
    }
}
