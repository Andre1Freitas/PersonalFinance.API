using PersonalFinance.API.Common;
using System.Text.RegularExpressions;

namespace PersonalFinance.API.Validations
{
    public class UserValidation
    {

        public Result ValidateName(string name)
        {
            return ValidationHelper.ValidateName(name);
        }
        public Result ValidateAge(int age)
        {
            if (age < 0 || age > 120)
            {
                return Result.Failure("The age must be between 0 and 120.");
            }
            return Result.Success();
        }

        public Result ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrWhiteSpace(email))
            {
                return Result.Failure("Email is empty");
            }
            if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                return Result.Failure("Invalid email");
            }
            return Result.Success();
        }
    }
}
