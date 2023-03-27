using MediatR;
using Microsoft.EntityFrameworkCore;
using Permissions.API.DbContexts;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetPermissionTypesByIdQueryHandler : IRequestHandler<GetPermissionTypesByIdQuery, PermissionTypes>
    {
        private readonly PermissionContext _context;

        public GetPermissionTypesByIdQueryHandler(PermissionContext context)
        {
            _context = context;
        }
        public async Task<PermissionTypes> Handle(GetPermissionTypesByIdQuery request, CancellationToken cancellationToken)
        {
            return await _context.PermissionTypes.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
        }
    }
}
