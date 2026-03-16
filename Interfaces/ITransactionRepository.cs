using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ITransactionRepository
    {
        void Add(Transaction transactions);
        void Remove(Guid transactionId);
        void Update(Guid transactionId, Transaction updatedTransaction);
        Transaction? GetById(Guid transactionId);
        List<Transaction> GetAllByUser(Guid userId);
        List<Transaction> GetPerPeriod(Guid userId, DateTime begin, DateTime end);
    }
}
