using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedFlowLibrary.Models
{
    public class TaskModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public string CreatorFirstName { get; set; }
        public string CreatorLastName { get; set; }
        public int AssignedTo { get; set; }
        public string AssigneeFirstName { get; set; }
        public string AssigneeLastName { get; set; }
    }
}
