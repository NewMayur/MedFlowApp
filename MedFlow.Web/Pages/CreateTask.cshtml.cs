using MedFlowLibrary.Data;
using MedFlowLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MedFlow.Web.Pages
{
    public class CreateTaskModel : PageModel
    {
        private readonly IDatabaseData _db;

        [BindProperty]
        public string Title { get; set; }

        //[DataType (DataType.Date)]
        //[BindProperty]
        //public DateTime DateCreated { get; set; } = DateTime.Now;

        [BindProperty]
        public int CreatedByUserId { get; set; }

        [BindProperty]
        public int AssginedToUserId { get; set; }


        public List<UserModel> Creators { get; set; }
        public List<UserModel> Assignee { get; set; }

        public CreateTaskModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {

            Creators = _db.GetUsersByAssignment(true);
            Assignee = _db.GetUsersByAssignment(false);
        }

        public IActionResult OnPost()
        {
            // Here, you can add code to handle form submission
            // For example, you can save the task to the database
            // and then redirect the user to another page
            if (!ModelState.IsValid)
            {
                // If model state is not valid, return the page with validation errors
                return Page();
            }

            // Create the task
            _db.CreateTask(Title, false, DateTime.Now, CreatedByUserId, AssginedToUserId);

            // Redirect to the index page
            return RedirectToPage("/Index");
        }
    }
}
