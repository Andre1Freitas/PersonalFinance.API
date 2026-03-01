using PersonalFinance.API.Enums;
using System.ComponentModel;

namespace PersonalFinance.API.Entities
{
    public class Transactions
    {
        public Guid UserId { get; set; }
        public Guid TransactionId { get; set; }
        public decimal Value { get; set; }
        public TransactionType TransactionType { get; set; }
        public Guid CategoryId { get; set; }
        public string DescriptionTransaction { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public Transactions(Guid userId, Guid transactionId, decimal value, TransactionType transactionType, Guid categoryId, string descriptionTransaction = "", DateTime date = default)
        {
            UserId = userId;
            TransactionId = transactionId;
            Value = value;
            TransactionType = transactionType;
            CategoryId = categoryId;
            DescriptionTransaction = descriptionTransaction;
            Date = date == default ? DateTime.UtcNow : date;
        }
    }
}