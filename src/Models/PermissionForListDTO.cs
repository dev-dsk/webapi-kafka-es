using System.ComponentModel.DataAnnotations;

namespace Permissions.API.Models
{
    public class PermissionForListDTO
    {
        public int Id { get; set; }

        public string EmployeeForename { get; set; } = string.Empty;

        public string EmployeeSurname { get; set; } = string.Empty;

        [Required]
        public int PermissionType { get; set; }

        public string LastUpdate { get; set; }
    }
}
