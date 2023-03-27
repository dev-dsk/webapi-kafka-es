namespace Permissions.UnitTests.DTOs
{
    public class PermissionRequestTest : BaseTest
    {
        [Theory]
        [InlineData(1, null, "Doe", 2, 1)]
        [InlineData(1, "Jhon", null, 3, 1)]
        [InlineData(1, null, null, 7, 2)]
        [InlineData(1, "Jhon", "Doe", 1, 0)]

        public void ValidateModel_UpdatePermissionRequest_ReturnCorrectNumberErrors(int id, string employeeForename, string employeeSurename, int permissionTypeId, int numberExpectedErrors )
        {
            var request = new UpdatePermissionCommand(id, employeeForename, employeeSurename, permissionTypeId);

            var errorList = ValidateModel(request);
            Assert.Equal(numberExpectedErrors, errorList.Count());
        }


    }
}
