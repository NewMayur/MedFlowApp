using MedFlowLibrary.Data;
using MedFlowLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedFlow.Web.Pages
{
    public class SearchUsersModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty]
        public int UserId { get; set; } = 1;
        public List<UserModel> Users { get; set; }
        public SearchUsersModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Users = _db.GetUserById(UserId);
        }
    }
}
