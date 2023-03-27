using MediatR;
using Microsoft.EntityFrameworkCore;
using Permissions.API.DbContexts;
using Permissions.API.Entities;
using Permissions.API.Models;

namespace Permissions.API.Resources.Queries
{
    public class GetPermissionByIdsQueryHandler : IRequestHandler<GetPermissionRequestByIdsQuery, bool>
    {
        private readonly PermissionContext _context;

        public GetPermissionByIdsQueryHandler(PermissionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<bool> Handle(GetPermissionRequestByIdsQuery request, CancellationToken cancellationToken)
        {
            var resource = await _context.Permissions.FirstOrDefaultAsync(u => u.Id == request.IdPermission 
                && u.PermissionTypes.Id == request.IdPermissionType, cancellationToken);

            if (resource == null) 
                return false;
            
            return true;
        }
    }
}
