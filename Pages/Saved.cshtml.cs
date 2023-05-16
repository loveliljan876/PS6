using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using PS6.Pages.Forms;

namespace PS6.Pages
{
    public class SavedModel : PageModel
    {
        [BindProperty]
        public List<YearResponse> YearResponses { get; set; }

        public SavedModel()
        {
            YearResponses = new List<YearResponse>();
        }

        public void OnGet()
        {
            YearResponses = GetResponses();
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
    }
}