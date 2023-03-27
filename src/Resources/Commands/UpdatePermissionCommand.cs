using MediatR;
using Permissions.API.Entities;
using System.ComponentModel.DataAnnotations;

namespace Permissions.API.Resources.Commands
{
    public class UpdatePermissionCommand : IRequest<Permission>
    {
        [Required(ErrorMessage = "You should provide a Permission Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "You need to provide an Employee forename")]
        [MaxLength(100, ErrorMessage = "Employee forename has a 100 max length, please please verify.")]
        public string EmployeeForename { get; set; }

        [Required(ErrorMessage = "You need to provide an Employee surname")]
        [MaxLength(100, ErrorMessage = "Employee surname has a 100 max length, please please verify.")]
        public string EmployeeSurname { get; set; }

        [Required(ErrorMessage = "You should provide a PermissionType Id")]
        public int PermissionType { get; set; }

        public UpdatePermissionCommand(int id = 0, string employeeForename = "", string employeeSurname = "", int permissionType = 0)
        {
            Id = id;
            EmployeeForename = employeeForename;
            EmployeeSurname = employeeSurname;
            PermissionType = permissionType;            
        }
    }
}
