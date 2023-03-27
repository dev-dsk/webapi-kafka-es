

namespace Permissions.UnitTests.DTOs
{
    public abstract class BaseTest
    {
        public IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();

            var context = new ValidationContext(model, null, null);           
            Validator.TryValidateObject(model, context, validationResults, true);
            
            return validationResults;
        }
    }
}
