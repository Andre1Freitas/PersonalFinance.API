namespace PersonalFinance.API.DTOs
{
    public class CreateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
