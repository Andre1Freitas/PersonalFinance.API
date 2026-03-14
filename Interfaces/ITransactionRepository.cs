using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ITransactionRepository
    {
        void Add(Transactions transactions);
        void Remove(Guid transactionId);
        void Update(Guid transactionId, Transactions updatedTransaction);
        Transactions? GetById(Guid transactionId);
        List<Transactions> GetAllByUser(Guid userId);
        List<Transactions> GetPerPeriod(Guid userId, DateTime begin, DateTime end);
    }
}
