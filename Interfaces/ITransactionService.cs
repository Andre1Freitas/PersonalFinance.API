using PersonalFinance.API.Common;
using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ITransactionService
    {
        public Result Add(Transactions transaction);
        public Result Remove(Guid transactionId);
        public Result Update(Guid transactionId, Transactions updatedTransaction);
        public Result<Transactions?> GetById(Guid transactionId);
        public Result<List<Transactions>> GetAllByUser(Guid userId);
        public Result<List<Transactions>> GetPerPeriod(Guid userId, DateTime begin, DateTime end);
    }
}
