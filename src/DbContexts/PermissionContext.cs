using Microsoft.EntityFrameworkCore;
using Permissions.API.Entities;

namespace Permissions.API.DbContexts
{
    public class PermissionContext : DbContext
    {
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionTypes> PermissionTypes { get; set; }

        public PermissionContext(DbContextOptions<PermissionContext> options) 
            : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PermissionTypes>()
                .HasData(
                    new PermissionTypes() { Id = 1, Description = "FullControl" },
                    new PermissionTypes() { Id = 2, Description = "Read" },
                    new PermissionTypes() { Id = 3, Description = "Write" },
                    new PermissionTypes() { Id = 4, Description = "Delete" },
                    new PermissionTypes() { Id = 5, Description = "List" },
                    new PermissionTypes() { Id = 6, Description = "Deny" }
                );

            modelBuilder.Entity<Permission>()
                .HasData(
                    new Permission() { Id = 1, EmployeeForename = "John", EmployeeSurname = "Doe", PermissionType = 1, PermissionDate = DateTime.Now },
                    new Permission() { Id = 2, EmployeeForename = "Mark", EmployeeSurname = "Smith", PermissionType = 2, PermissionDate = DateTime.Now.AddMinutes(-1) },
                    new Permission() { Id = 3, EmployeeForename = "Jane", EmployeeSurname = "Doe", PermissionType = 3, PermissionDate = DateTime.Now.AddMinutes(-4) },
                    new Permission() { Id = 4, EmployeeForename = "Mary", EmployeeSurname = "Coptom", PermissionType = 4, PermissionDate = DateTime.Now.AddMinutes(-5) },
                    new Permission() { Id = 5, EmployeeForename = "John", EmployeeSurname = "Carpenter", PermissionType = 1, PermissionDate = DateTime.Now.AddMinutes(-10) }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}

