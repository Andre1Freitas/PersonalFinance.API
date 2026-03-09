using PersonalFinance.API.Entities;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Interfaces
{
    public interface IUserService
    {
        public Result Add(User user);
        public Result Remove(Guid userId);
        public Result Update(Guid userId, User updatedUser);
        public Result<User> GetById(Guid userId);
        public Result<List<User>> GetAll();

    }
}
