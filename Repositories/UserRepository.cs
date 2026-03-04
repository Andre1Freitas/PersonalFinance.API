using Microsoft.EntityFrameworkCore;
using PersonalFinance.API.Data;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;

namespace PersonalFinance.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Remove(Guid userId) => _context.Users.Where(p => p.UserId == userId).ExecuteDelete();

        public void Update(Guid userId, User updatedUser)
        {
            _context.Users.
                Where(p => p.UserId == userId).
                ExecuteUpdate(s => s
                .SetProperty(f => f.Name, updatedUser.Name)
                .SetProperty(f => f.Age, updatedUser.Age)
                .SetProperty(f => f.Email, updatedUser.Email));
        }

        public User? GetById(Guid userId) => _context.Users.Find(userId);

        public List<User> GetAll() => _context.Users.ToList();
     }
}
