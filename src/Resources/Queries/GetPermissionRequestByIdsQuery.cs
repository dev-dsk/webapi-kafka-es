using MediatR;
using MediatR.Pipeline;
using Permissions.API.Entities;
using Permissions.API.Models;

namespace Permissions.API.Resources.Queries
{
    public class GetPermissionRequestByIdsQuery : IRequest<bool>
    {
        public GetPermissionRequestByIdsQuery(int permissionId, int permissionType)
        {
            IdPermission = permissionId;
            IdPermissionType = permissionType;
        }

        public int IdPermission { get; set; }
        public int IdPermissionType { get; set; }
    }
}
