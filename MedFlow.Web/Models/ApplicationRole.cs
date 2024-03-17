using Microsoft.AspNetCore.Identity;

namespace MedFlow.Web.Models
{
    public class ApplicationRole : IdentityRole
    {
        public bool CanCreateTask { get; set; }
        public bool CanAssignTask { get; set; }
    }
}
