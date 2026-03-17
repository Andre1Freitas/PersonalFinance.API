using System.Security.Cryptography;

namespace PersonalFinance.API.Entities
{
    public class User
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public Guid UserId { get; set; }
        public string PasswordHash { get; set; }

        public User(string name, int age, string email, string passwordHash)
        {
            Name = name;
            Age = age;
            Email = email;
            UserId = Guid.NewGuid();
            PasswordHash = passwordHash;
        }
    }
}
