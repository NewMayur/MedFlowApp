using MedFlowLibrary.Data;
using MedFlowLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace MedFlow.Web.Pages
{
    //public class CreatedTasksModel : PageModel
    //{
    //    private readonly IDatabaseData _db;

    //    [BindProperty(SupportsGet = true)]
    //    public string Title { get; set; }


    //    [DataType(DataType.Date)]
    //    [BindProperty(SupportsGet = true)]
    //    public DateTime DateCreated { get; set; }



    //    [BindProperty(SupportsGet = true)]
    //    public bool Status { get; set; }



    //    [BindProperty(SupportsGet = true)]
    //    public int CreatedBy { get; set; }
    //    [BindProperty(SupportsGet = true)]
    //    public string CreatorFirstName { get; set; }
    //    [BindProperty(SupportsGet = true)]
    //    public string CreatorLastName { get; set; }


    //    [BindProperty(SupportsGet = true)]
    //    public int AssignedTo { get; set; }
    //    public string AssigneeFirstName { get; set; }
    //    public string AssigneeLastName { get; set; }

    //    public List<TaskModel> Tasks { get; set; }

    //    public CreatedTasksModel(IDatabaseData db)
    //    {
    //        _db = db;
    //    }

    //    [BindProperty(SupportsGet =true)]
    //    public int UserId { get; set; } = 1;

    //    [BindProperty(SupportsGet = true)]
    //    public bool IsAssigned { get; set; } = false;

    //    public void OnGet()
    //    {
    //        Tasks = _db.GetTasksByIdAssignment(UserId, IsAssigned);
    //    }
    //}
    public class CreatedTasksModel : PageModel
    {
        private readonly IDatabaseData _db;

        public List<TaskModel> Tasks { get; set; }

        public CreatedTasksModel(IDatabaseData db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Tasks = _db.GetTasksByIdAssignment(1, false);
        }
    }
}
