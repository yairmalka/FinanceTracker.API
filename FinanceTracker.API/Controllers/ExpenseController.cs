using FinanceTracker.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.API.Models;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Data;
using FinanceTracker.API.Repositories.Interface;
using System.Reflection.Metadata.Ecma335;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpenseController(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense(CreateExpenseRequestDto request)
        {
            var expense = new Expense
            {
                ExpenseCategoryId = request.ExpenseCategoryId,
                UserId = request.UserId,
                DateOfExpense = request.DateOfExpense,
                Amount = request.Amount,
                ReceiptImageUrl = request.ReceiptImageUrl,
                Currency = request.Currency,
                Location = request.Location

            };
            try
            {
                await expenseRepository.CreateAsync(expense);
                var responseExpense = new ExpenseDto(expense);
                return Created("api/Expense/" + responseExpense.ExpenseId, responseExpense);
            }
            catch (Exception ex) { 
                return StatusCode(StatusCodes.Status500InternalServerError,ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpensesAsync()
        {
            try
            {
                var expenses = await expenseRepository.GetAllExpensesAsync();
                var response = new List<ExpenseDto>();

                foreach(var expense in expenses)
                {
                    response.Add(new ExpenseDto(expense));
                }

                return Ok(response);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetExpenseByIdAsync(Guid id)
        {
            try
            {
                var response = await expenseRepository.GetExpenseByIdAsync(id);

                if (response == null)
                    return NotFound();

                return Ok(new ExpenseDto(response));
            }
            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditExpense(Guid id, EditExpenseRequestDto request)
        {
            var expense = new Expense
            {
                ExpenseId = id,
                ExpenseCategoryId = request.ExpenseCategoryId,
                DateOfExpense = request.DateOfExpense,
                Amount = request.Amount,
                ReceiptImageUrl = request.ReceiptImageUrl,
                Currency = request.Currency,
                Location = request.Location
            };
            try { 
            expense = await expenseRepository.EditExpense(expense);

            if (expense == null)
                return NotFound();

            return Ok(new ExpenseDto(expense));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
  
        }
    }
}
