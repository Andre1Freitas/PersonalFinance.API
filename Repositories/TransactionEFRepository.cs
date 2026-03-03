using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Data;
using Microsoft.EntityFrameworkCore;

namespace PersonalFinance.API.Repositories
{
    public class TransactionEFRepository : ITransactionsRepository
    {
        private readonly AppDbContext _context;

        public TransactionEFRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add (Transactions transaction)
        {
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }
        public void Remove(Guid transactionId)
        {
            _context.Transactions.Where(p => p.TransactionId == transactionId).ExecuteDelete();
        }
        public void Update(Guid transactionId, Transactions updatedTransaction)
        {
            _context.Transactions.
                Where(p => p.TransactionId == transactionId).
                ExecuteUpdate(s => s
                .SetProperty(f => f.Value, updatedTransaction.Value)
                .SetProperty(f => f.TransactionType, updatedTransaction.TransactionType)
                .SetProperty(f => f.DescriptionTransaction, updatedTransaction.DescriptionTransaction)
                .SetProperty(f => f.Date, updatedTransaction.Date));
        }
        public Transactions? GetById(Guid transactionId) => _context.Transactions.Find(transactionId);

        public List<Transactions> GetAllByUser(Guid userId) => _context.Transactions.Where(p => p.UserId == userId).ToList();

        public List<Transactions> GetPerPeriod(Guid userId, DateTime begin, DateTime end) => _context.Transactions.Where(p => p.UserId == userId).Where(p => p.Date > begin && p.Date < end).ToList();
    }
}
