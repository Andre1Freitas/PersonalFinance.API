using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Validations;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserValidation _userValidation;

        public UserService(IUserRepository userRepository, UserValidation userValidation)
        {
            _userRepository = userRepository;
            _userValidation = userValidation;
        }

        public Result Add(User user)
        {
            Result result = _userValidation.ValidateName(user.Name);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _userValidation.ValidateAge(user.Age);
            if(!result.IsSuccess)
            {
                return result;
            }
            result = _userValidation.ValidateEmail(user.Email);
            if(!result.IsSuccess)
            {
                return result;
            }

            _userRepository.Add(user);
            return Result.Success();
        }

        public Result Remove(Guid userId)
        {
            Result result = _userValidation.ValidateUserId(userId);
            if(!result.IsSuccess)
            {
                return result;
            }
            _userRepository.Remove(userId);
            return Result.Success();
        }

        public Result Update(Guid userId, User updatedUser)
        {
            Result result = _userValidation.ValidateName(updatedUser.Name);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _userValidation.ValidateAge(updatedUser.Age);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _userValidation.ValidateEmail(updatedUser.Email);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _userValidation.ValidateUserId(userId);
            if (!result.IsSuccess)
            {
                return result;
            }

            _userRepository.Update(userId, updatedUser);
            return Result.Success();
        }

        public Result<User> GetById(Guid userId)
        {
            Result result = _userValidation.ValidateUserId(userId);
            if (!result.IsSuccess)
            {
                return Result<User>.Failure(result.Error);
            }
            return Result<User>.Success(_userRepository.GetById(userId));
        }

        public Result<List<User>> GetAll()
        {
            return Result<List<User>>.Success(_userRepository.GetAll());
        }
    }
}
