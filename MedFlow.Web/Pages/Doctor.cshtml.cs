using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedFlow.Web.Pages
{
    [Authorize(Roles = "doctor")]
    public class DoctorModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
