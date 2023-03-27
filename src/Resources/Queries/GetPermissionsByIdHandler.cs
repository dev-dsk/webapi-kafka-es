using MediatR;
using Microsoft.EntityFrameworkCore;
using Permissions.API.DbContexts;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetPermissionsByIdQueryHandler : IRequestHandler<GetPermissionsByIdQuery, Permission>
    {
        private readonly PermissionContext _context;
        public GetPermissionsByIdQueryHandler(PermissionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Permission> Handle(GetPermissionsByIdQuery request, CancellationToken cancellationToken) 
        {
            return await _context.Permissions.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        }
            
    }
}
