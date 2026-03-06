using PersonalFinance.API.Common;

namespace PersonalFinance.API.Validations
{
    public class CategoryValidation
    {
        public Result ValidateName(string name)
        {
            return ValidationHelper.ValidateName(name);
        }

        public Result ValidateUserId(Guid id)
        {
            return ValidationHelper.ValidateGuid(id);
        }
    }
}
