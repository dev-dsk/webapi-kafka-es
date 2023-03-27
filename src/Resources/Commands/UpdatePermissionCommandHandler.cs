using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Permissions.API.DbContexts;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Commands
{
    public class UpdatePermissionCommandHandler : IRequestHandler<UpdatePermissionCommand, Permission>
    {
        private readonly PermissionContext _context;

        public UpdatePermissionCommandHandler(PermissionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Permission> Handle(UpdatePermissionCommand request, CancellationToken cancellationToken)
        {            
            var permission = _context.Permissions.FirstOrDefault(p => p.Id == request.Id);

            if (permission is null) 
                return default;

            var permissionType = _context.PermissionTypes.AsNoTracking().FirstOrDefault(p => p.Id == request.PermissionType);
            
            if (permissionType is null)
                return default;

            permission.EmployeeForename = request.EmployeeForename;
            permission.EmployeeSurname = request.EmployeeSurname;
            permission.PermissionType = request.PermissionType;
            permission.PermissionDate = DateTime.Now;

            /*
            var updateResource = new Permission(request.EmployeeForename, request.EmployeeSurname)
            {
                Id = request.Id,
                PermissionType = request.PermissionType,
                PermissionDate = DateTime.Now
            };
            */

            _context.Update(permission);
            await _context.SaveChangesAsync(cancellationToken);
            return permission;
        }
    }
}
