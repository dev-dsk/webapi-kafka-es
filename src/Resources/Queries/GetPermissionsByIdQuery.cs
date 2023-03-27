using MediatR;
using Permissions.API.Entities;

namespace Permissions.API.Resources.Queries
{
    public class GetPermissionsByIdQuery : IRequest<Permission>
    {
        public int Id { get; set; }
    }
}
