using PersonalFinance.API.Common;

namespace PersonalFinance.API.Validations
{
    public class TransactionValidation
    {
        public Result ValidateValue(decimal value)
        {
            if (value < 0)
            {
                return Result.Failure("Value is bellow zero!");
            }
            return Result.Success();
        }

        public Result ValidateDate(DateTime begin, DateTime end)
        {
            if (begin > end)
            {
                return Result.Failure("End date prior to start date");
            }
            return Result.Success();
        }

        public Result ValidateUserId(Guid id)
        {
            return ValidationHelper.ValidateGuid(id);
        }

        public Result ValidateCategoryId(Guid id)
        {
            return ValidationHelper.ValidateGuid(id);
        }
    }
}
