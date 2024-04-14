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
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseRepository expenseRepository;

        public ExpensesController(IExpenseRepository expenseRepository)
        {
            this.expenseRepository = expenseRepository;
        }

        [HttpGet]
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

             await expenseRepository.CreateAsync(expense);

            var response = new ExpenseDto
            {
                Id = expense.Id,
                DateOfExpense = expense.DateOfExpense,
                Amount = expense.Amount,
                Category = expense.Category,
                ReceiptImageUrl = expense.ReceiptImageUrl,
                Currency = expense.Currency,
                Location = expense.Location
            };
            return Ok(response);
        }




    }
}
