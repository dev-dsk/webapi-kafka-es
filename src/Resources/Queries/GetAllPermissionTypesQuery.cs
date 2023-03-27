using MediatR;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetAllPermissionTypesQuery : IRequest<IEnumerable<PermissionTypes>>
    {
    }
}
