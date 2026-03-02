using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        void Remove(Guid userId);
        void Update(Guid userId, User updatedUser);
        User GetById(Guid userId);
        List<User> GetAll();
    }
}
