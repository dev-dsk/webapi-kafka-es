using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Identity.Client;
using Permissions.API.Resources.Commands;
using Permissions.API.Resources.Queries;

namespace Permissions.IntegtationTests.Repositories
{
    public class PermissionsRepositoryTests : IClassFixture<SharedDatabaseFixture>
    {
        private readonly IMapper _mapper;
        private SharedDatabaseFixture _fixture { get; }
        
        public PermissionsRepositoryTests(SharedDatabaseFixture fixture) 
        { 
            _fixture = fixture;
            
            _mapper = new MapperConfiguration(cfg => { 
                            cfg.AddProfile<PermissionProfile>(); 
                         }).CreateMapper();            
        }

        [Fact]
        public async Task GetPermissions_AllPermissions()
        {
            using var context = _fixture.CreateContext();
            var repository = new GetAllPermissionsQueryHandler(context);

            var permissions = await repository.Handle(new GetAllPermissionsQuery(), CancellationToken.None);

            Assert.Equal(15, permissions?.Count());
        }

        [Fact]
        public async Task GetPermissions_OnePermission()
        {
            var Id = 1;

            using var context = _fixture.CreateContext();
            var repository = new GetPermissionsByIdQueryHandler(context);

            var permissions = await repository.Handle(new GetPermissionsByIdQuery() { Id = Id }, CancellationToken.None);

            Assert.Equal(Id, permissions.Id);
        }


        [Fact]
        public async Task GetPermissions_RequestPermissionTrue()
        {
            int IdPermission = 1;
            int IdPermissionType = 1;

            using var context = _fixture.CreateContext();
            var repository = new GetPermissionByIdsQueryHandler(context);
            var request = new GetPermissionRequestByIdsQuery(IdPermission, IdPermissionType);

            var permissions = await repository.Handle(request, CancellationToken.None);

            Assert.True(permissions);
        }

        [Fact]
        public async Task GetPermissions_RequestPermissionFalse()
        {
            int IdPermission = 1;
            int IdPermissionType = 10;

            using var context = _fixture.CreateContext();
            var repository = new GetPermissionByIdsQueryHandler(context);
            var request = new GetPermissionRequestByIdsQuery(IdPermission, IdPermissionType);

            var permissions = await repository.Handle(request, CancellationToken.None);

            Assert.False(permissions);
        }


        [Fact]
        public async Task UpdatePermission_SaveData()
        {
            using var transaction = _fixture.connection.BeginTransaction();
            var request = new UpdatePermissionCommand
            {
                EmployeeForename = "Test Unit",
                EmployeeSurname = "Test Unit",
                PermissionType = 1,
                Id = 1
            };

            using (var context = _fixture.CreateContext(transaction))
            {
                var handler = new UpdatePermissionCommandHandler(context);

                await handler.Handle(request, CancellationToken.None);
            }

            using (var context = _fixture.CreateContext(transaction))
            {
                var handler = new GetPermissionsByIdQueryHandler(context);

                var permissionEntity = await handler.Handle(new GetPermissionsByIdQuery() { Id = request.Id }, CancellationToken.None);

                Assert.NotNull(permissionEntity);
                Assert.Equal(request.EmployeeForename, permissionEntity.EmployeeForename);
                Assert.Equal(request.EmployeeSurname, permissionEntity.EmployeeSurname);
                Assert.Equal(request.PermissionType, permissionEntity.PermissionType);
                Assert.Equal(request.Id, permissionEntity.Id);
            }
        }
    }
}
