using MedFlowLibrary.Data;
using MedFlowLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedFlow.Web.Pages
{
    public class SearchUsersModel : PageModel
    {
        private readonly IDatabaseData _db;

        public List<UserModel> Creators { get; set; }

        //public bool CanAssign { get; set; } = true;
        public SearchUsersModel(IDatabaseData db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Creators = _db.GetUsersByAssignment(false);
        }
    }
}
