using Microsoft.AspNetCore.Mvc;
using PersonalFinance.API.DTOs;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Common;

namespace PersonalFinance.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateTransactionDto dto)
        {
            var transaction = new Transactions(dto.UserId, dto.Value, dto.TransactionType, dto.CategoryId, dto.DescriptionTransaction, dto.Date);
            Result result = _transactionService.Add(transaction);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionId}, transaction);
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(Guid id)
        {
            Result result = _transactionService.Remove(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] UpdateTransactionDto dto)
        {
            var transaction = new Transactions(dto.UserId, dto.Value, dto.TransactionType, dto.CategoryId, dto.DescriptionTransaction, dto.Date);
            Result result = _transactionService.Update(id, transaction);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(transaction);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            Result<Transactions?> result = _transactionService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("user/{id}")]
        public IActionResult GetAllByUser(Guid id)
        {
            Result<List<Transactions>> result = _transactionService.GetAllByUser(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpGet("period")]
        public IActionResult GetPerPeriod(Guid id, DateTime begin, DateTime end)
        {
            Result<List<Transactions>> result = _transactionService.GetPerPeriod(id, begin, end);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }
    }
}
