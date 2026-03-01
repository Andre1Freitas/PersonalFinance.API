using System.Security.Cryptography;

namespace PersonalFinance.API.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public Category(string name, Guid userId)
        {
            Name = name;
            CategoryId = Guid.NewGuid();
            UserId = userId;
        }
    }
}
