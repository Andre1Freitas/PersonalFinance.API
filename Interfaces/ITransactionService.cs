using PersonalFinance.API.Common;
using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ITransactionService
    {
        public Result Add(Transaction transaction);
        public Result Remove(Guid transactionId);
        public Result Update(Guid transactionId, Transaction updatedTransaction);
        public Result<Transaction?> GetById(Guid transactionId);
        public Result<List<Transaction>> GetAllByUser(Guid userId);
        public Result<List<Transaction>> GetPerPeriod(Guid userId, DateTime begin, DateTime end);
    }
}
