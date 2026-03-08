using PersonalFinance.API.Enums;

namespace PersonalFinance.API.DTOs
{
    public class UpdateTransactionDto
    {
        public Guid UserId { get; set; }
        public decimal Value { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid CategoryId { get; set; }
        public string DescriptionTransaction { get; set; } = string.Empty;
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
