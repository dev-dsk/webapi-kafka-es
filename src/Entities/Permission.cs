using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Permissions.API.Entities
{
    public class Permission
    {        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        public string EmployeeForename { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string EmployeeSurname { get; set; } = string.Empty;

        [ForeignKey("PermissionType")]
        public PermissionTypes? PermissionTypes { get; set; }
        
        public int PermissionType { get; set; }
        
        public DateTime PermissionDate { get; set; }
    }
}
