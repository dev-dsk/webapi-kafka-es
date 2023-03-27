using MediatR;
using Microsoft.EntityFrameworkCore;
using Permissions.API.DbContexts;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetAllPermissionsQueryHandler : IRequestHandler<GetAllPermissionsQuery, IEnumerable<Permission>>
    {
        private readonly PermissionContext _context;

        public GetAllPermissionsQueryHandler(PermissionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Permission>> Handle(GetAllPermissionsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Permissions.ToListAsync(cancellationToken);
        }
    }
}
