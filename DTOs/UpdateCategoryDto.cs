namespace PersonalFinance.API.DTOs
{
    public class UpdateCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public Guid UserId { get; set; }
    }
}
