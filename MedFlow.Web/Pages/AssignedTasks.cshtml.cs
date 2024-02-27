using MedFlowLibrary.Data;
using MedFlowLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MedFlow.Web.Pages
{
    public class AssignedTasksModel : PageModel
    {
        private readonly IDatabaseData _db;

        public List<TaskModel> Tasks { get; set; }

        [BindProperty(SupportsGet =true)]
        public int AssignedTo { get; set; }

        public List<UserModel> Assignee { get; set; }

        public AssignedTasksModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Assignee = _db.GetUsersByAssignment(false);
        }

        public IActionResult OnPost()
        {

            if (Request.Form.TryGetValue("markAsDone", out var taskIdValue))
            {
                if (int.TryParse(taskIdValue, out var taskId))
                {
                    _db.UpdateTaskStatus(taskId); // Update task status to true (completed)
                    return RedirectToPage("/AssignedTasks"); // Redirect back to the same page
                }
            }

            Tasks = _db.GetTasksByIdAssignment(AssignedTo, true);
            Assignee = _db.GetUsersByAssignment(false);
            return Page();
        }

        public IActionResult OnPostMarkAsDone(int taskId)
        {
            _db.UpdateTaskStatus(taskId); // Update task status to true (completed)
            return RedirectToPage("/AssignedTasks"); // Redirect back to the same page
        }


    }
}
