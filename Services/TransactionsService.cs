using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Validations;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Services
{
    public class TransactionsService : ITransactionService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly TransactionValidation _transactionValidation;

        public TransactionsService(ITransactionsRepository transactionsRepository, TransactionValidation transactionValidation)
        {
            _transactionsRepository = transactionsRepository;
            _transactionValidation = transactionValidation;
        }

        public Result Add(Transactions transaction)
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

        public Result Update(Guid transactionId, Transactions updatedTransaction)
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

        public Result<Transactions?> GetById(Guid transactionId)
        {
            Result result = _transactionValidation.ValidateTransactionId(transactionId);
            if (!result.IsSuccess)
            {
                return Result<Transactions?>.Failure(result.Error);
            }
            return Result<Transactions?>.Success(_transactionsRepository.GetById(transactionId));
        }

        public Result<List<Transactions>> GetAllByUser(Guid userId)
        {
            Result result = _transactionValidation.ValidateUserId(userId);
            if (!result.IsSuccess)
            {
                return Result<List<Transactions>>.Failure(result.Error);
            }
            return Result<List<Transactions>>.Success(_transactionsRepository.GetAllByUser(userId));
        }

        public Result<List<Transactions>> GetPerPeriod(Guid userId, DateTime begin, DateTime end)
        {
            Result result = _transactionValidation.ValidateDate(begin, end);
            if(!result.IsSuccess)
            {
                return Result<List<Transactions>>.Failure(result.Error);
            }
            result = _transactionValidation.ValidateUserId(userId);
            if (!result.IsSuccess)
            {
                return Result<List<Transactions>>.Failure(result.Error);
            }
            return Result<List<Transactions>>.Success(_transactionsRepository.GetPerPeriod(userId, begin, end));
        }
    }
}
