using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ITransactionsRepository
    {
        void Add(Transactions transactions);
        void Remove(Guid transactionId);
        void Update(Guid transactionId, Transactions updatedTransaction);
        Transactions GetById(Guid transactionId);
        List<Transactions> GetAllByUser(Guid userId);
        List<Transactions> GetTransactionsPerPeriod(Guid userId, DateTime begin, DateTime end);
    }
}
