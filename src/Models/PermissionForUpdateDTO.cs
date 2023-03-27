using Permissions.API.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Permissions.API.Models
{
    public class PermissionForUpdateDTO
    {
        [Required(ErrorMessage = "You need to provide an Employee forename")]
        [MaxLength(100, ErrorMessage = "Employee forename has a 100 max length, please please verify.")]
        public string EmployeeForename { get; set; } = string.Empty;

        [Required(ErrorMessage = "You need to provide an Employee surname")]
        [MaxLength(100, ErrorMessage = "Employee surname has a 100 max length, please please verify.")]
        public string EmployeeSurname { get; set; } = string.Empty;

        [Required(ErrorMessage = "You should provide a PermissionType Id")]
        public int PermissionType { get; set; }
    }
}
