using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PS6.Areas.Data.Models;
using PS6.Areas.YearDb;
using PS6.Pages.Forms;
using System.Security.Claims;

namespace PS6.Pages
{
    public class IndexModel : PageModel
    {
        private readonly YearDbContext dbContext;

        [BindProperty(SupportsGet = true)]
        public YearForm Form { get; set; }

        public YearResponse? YearResponse { get; set; }

        public IndexModel(YearDbContext dbContext)
        {
            Form = new YearForm();
            YearResponse = null;
            this.dbContext = dbContext;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                YearResponse = new YearResponse(Form.Name, Form.Year.Value);
                SaveInSession(YearResponse);
                SaveInDatabase(YearResponse);
            }

            return Page();
        }

        public List<YearResponse> GetResponses()
        {
            List<YearResponse>? currentList = new List<YearResponse>();
            var data = HttpContext.Session.GetString("Data");

            if (data != null)
            {
                currentList = JsonConvert.DeserializeObject<List<YearResponse>>(data);
                if (currentList == null)
                {
                    currentList = new List<YearResponse>();
                }
            }

            return currentList;
        }

        public void SaveInSession(YearResponse response)
        {
            var currentList = GetResponses();

            currentList.Add(response);
            HttpContext.Session.SetString("Data", JsonConvert.SerializeObject(currentList));
        }

        public void SaveInDatabase(YearResponse response)
        {
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var userName = HttpContext.User.Identity.Name;

            var yearValidationResult = new YearValidationResult
            {
                Year = response.Year,
                Result = response.ToString(),
                TimeAdded = DateTime.Now,
                UserId = userId,
                UserLogin = userName
            };

            dbContext.YearValidationResult.Add(yearValidationResult);
            dbContext.SaveChanges();
        }
    }
}