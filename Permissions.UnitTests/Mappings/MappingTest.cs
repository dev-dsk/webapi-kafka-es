namespace Permissions.UnitTests.Mappings
{
    public class MappingTest
    {
        private readonly IConfigurationProvider _configuration;
        private readonly IMapper _mapper;

        public MappingTest()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PermissionProfile>();
            });

            _mapper = _configuration.CreateMapper();
        }

        [Fact]
        public void ShouldBeValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }

        [Theory]
        [InlineData(typeof(PermissionForUpdateDTO), typeof(UpdatePermissionCommand))]
        [InlineData(typeof(Permission), typeof(PermissionForUpdateDTO))]
        [InlineData(typeof(Permission), typeof(PermissionForListDTO))]
        [InlineData(typeof(PermissionForUpdateDTO), typeof(Permission))]

        public void Map_SourcetoDestination_ExistConfiguration(Type origin, Type destination)
        {
            var instance = FormatterServices.GetUninitializedObject(origin);

            _mapper.Map(instance, origin, destination);
        }
    }
}
