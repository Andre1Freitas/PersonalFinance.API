using PersonalFinance.API.Common;
using System.Text.RegularExpressions;

namespace PersonalFinance.API.Validations
{
    public static class ValidationHelper
    {
        public static Result ValidateName(string name)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return Result.Failure("Name is empty!");
            }
            if (name.Length < 2)
            {
                return Result.Failure("Name is too short!");
            }
            if (name.Length > 50)
            {
                return Result.Failure("Name is too long!");
            }
            if (Regex.IsMatch(name, @"\d"))
            {
                return Result.Failure("Name have numbers!");
            }
            if (!Regex.IsMatch(name, @"^[\p{L}\s]+$"))
            {
                return Result.Failure("Name have especial characters!");
            }
            return Result.Success();
        }

        public static Result ValidateGuid(Guid id)
        {
            if (id == Guid.Empty)
            {
                return Result.Failure("Is not a valid id!");
            }
            return Result.Success();
        }
    }
}
