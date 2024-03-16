using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace MedFlow.Web.Pages
{
    [Authorize(Roles = "intern")]
    public class InternModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
