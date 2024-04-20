using FinanceTracker.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinanceTracker.API.Models;
using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Data;
using FinanceTracker.API.Repositories.Interface;

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
                DateOfExpense = request.DateOfExpense,
                Amount = request.Amount,
                Category = request.Category,
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




    }
}
