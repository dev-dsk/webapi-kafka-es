using MediatR;
using Microsoft.EntityFrameworkCore;
using Permissions.API.DbContexts;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetAllPermissionTypesQueryHandler : IRequestHandler<GetAllPermissionTypesQuery, IEnumerable<PermissionTypes>>
    {
        private readonly PermissionContext _context;

        public GetAllPermissionTypesQueryHandler(PermissionContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<PermissionTypes>> Handle(GetAllPermissionTypesQuery request, CancellationToken cancellationToken)
        {
            return await _context.PermissionTypes.ToListAsync();
        }
    }
}
