using MedFlowLibrary.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedFlow.Web.Pages
{
    public class CreateTaskModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty]
        public string Title { get; set; }
        public void OnGet()
        {
        }

        public CreateTaskModel(IDatabaseData db)
        {
            _db = db;
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
