using MediatR;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetPermissionTypesByIdQuery : IRequest<PermissionTypes>
    {
        public int Id { get; set; }
    }
}
