

namespace Permissions.IntegtationTests
{
    public class SharedDatabaseFixture : IDisposable
    {
        private static readonly object _lock = new object();
        private static bool _databaseInitialized;
        private string dbName = "TestDB.db";

        public DbConnection connection { get; }

        public SharedDatabaseFixture()
        {
            connection = new SqliteConnection($"Filename={dbName}");
            Seed();
            connection.Open();
        }

        public PermissionContext CreateContext(DbTransaction ? transaction = null)
        {
            var context = new PermissionContext(new DbContextOptionsBuilder<PermissionContext>().UseSqlite(connection).Options);

            if (transaction != null)
            {
                context.Database.UseTransaction(transaction);
            }

            return context;
        }



        private void Seed()
        {
            lock(_lock ) 
            {
                if (!_databaseInitialized)
                {
                    using var context = CreateContext();
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    SeedData(context);
                }
                _databaseInitialized = true;
            }
            
        }

        private void SeedData(PermissionContext context)
        {
            var permissionId = 6;
            var fakePermissions = new Faker<Permission>().RuleFor(x => x.EmployeeForename, f => $"Forename {permissionId}")
                                                         .RuleFor(x => x.EmployeeSurname, f => $"Surname {permissionId}")
                                                         .RuleFor(x => x.Id, f => permissionId++)
                                                         .RuleFor(x => x.PermissionType, f => f.Random.Number(1, 6))
                                                         .RuleFor(x => x.PermissionDate, f => DateTime.Now.AddMinutes(f.Random.Number(1, 6)));


            var permissions = fakePermissions.Generate(10);
            context.AddRange(permissions);


            var permissionTypeId = 1;

            var fakePermissionTypes = new Faker<PermissionTypes>().RuleFor(x => x.Description, f => $"Type {permissionTypeId}");


            var permissionTypes = fakePermissionTypes.Generate(6);
            context.AddRange(permissionTypes);

            context.SaveChanges();                                                         
        }

        public void Dispose() => connection.Dispose();
    }
}
