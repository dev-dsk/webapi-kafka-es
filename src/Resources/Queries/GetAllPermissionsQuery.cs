using MediatR;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetAllPermissionsQuery : IRequest<IEnumerable<Permission>>
    {        
    }
}
