using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Validations;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionsRepository;
        private readonly TransactionValidation _transactionValidation;

        public TransactionService(ITransactionRepository transactionsRepository, TransactionValidation transactionValidation)
        {
            _transactionsRepository = transactionsRepository;
            _transactionValidation = transactionValidation;
        }

        public Result Add(Transaction transaction)
        {
            Result result = _transactionValidation.ValidateValue(transaction.Value);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _transactionValidation.ValidateUserId(transaction.UserId);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _transactionValidation.ValidateCategoryId(transaction.CategoryId);
            if (!result.IsSuccess)
            {
                return result;
            }

            _transactionsRepository.Add(transaction);
            return Result.Success();
        }

        public Result Remove(Guid transactionId)
        {
            Result result = _transactionValidation.ValidateTransactionId(transactionId);
            if (!result.IsSuccess)
            {
                return result;
            }
            _transactionsRepository.Remove(transactionId);
            return Result.Success();
        }

        public Result Update(Guid transactionId, Transaction updatedTransaction)
        {
            Result result = _transactionValidation.ValidateValue(updatedTransaction.Value);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _transactionValidation.ValidateUserId(updatedTransaction.UserId);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _transactionValidation.ValidateCategoryId(updatedTransaction.CategoryId);
            if (!result.IsSuccess)
            {
                return result;
            }

            result = _transactionValidation.ValidateTransactionId(transactionId);
            if (!result.IsSuccess)
            {
                return result;
            }

            _transactionsRepository.Update(transactionId, updatedTransaction);
            return Result.Success();
        }

        public Result<Transaction?> GetById(Guid transactionId)
        {
            Result result = _transactionValidation.ValidateTransactionId(transactionId);
            if (!result.IsSuccess)
            {
                return Result<Transaction?>.Failure(result.Error);
            }
            return Result<Transaction?>.Success(_transactionsRepository.GetById(transactionId));
        }

        public Result<List<Transaction>> GetAllByUser(Guid userId)
        {
            Result result = _transactionValidation.ValidateUserId(userId);
            if (!result.IsSuccess)
            {
                return Result<List<Transaction>>.Failure(result.Error);
            }
            return Result<List<Transaction>>.Success(_transactionsRepository.GetAllByUser(userId));
        }

        public Result<List<Transaction>> GetPerPeriod(Guid userId, DateTime begin, DateTime end)
        {
            Result result = _transactionValidation.ValidateDate(begin, end);
            if(!result.IsSuccess)
            {
                return Result<List<Transaction>>.Failure(result.Error);
            }
            result = _transactionValidation.ValidateUserId(userId);
            if (!result.IsSuccess)
            {
                return Result<List<Transaction>>.Failure(result.Error);
            }
            return Result<List<Transaction>>.Success(_transactionsRepository.GetPerPeriod(userId, begin, end));
        }
    }
}
