namespace PersonalFinance.API.Entities
{
    public class Category
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public Category(string name, Guid categoryId, Guid userId)
        {
            Name = name;
            CategoryId = categoryId;
            UserId = userId;
        }
    }
}
