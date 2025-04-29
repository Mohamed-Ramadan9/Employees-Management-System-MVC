using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace Employee_Management_System.Models
{
    public class SystemCode:UserActivity
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }
        
    }
}
