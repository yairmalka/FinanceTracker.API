using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
using FinanceTracker.API.Repositories.Implementation;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseCategoryController : ControllerBase
    {
        private readonly IExpenseCategoryRepository expenseCategoryRepository;

        public ExpenseCategoryController(IExpenseCategoryRepository expenseCategoryRepository)
        {
            this.expenseCategoryRepository = expenseCategoryRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddExpenseCategory(AddExpenseCategoryRequest request)
        {
            var expenseCategory = new ExpenseCategory
            {
                CategoryExpenseName = request.CategoryExpenseName
            };
            try
            {
                await expenseCategoryRepository.AddExpenseCategoryAsync(expenseCategory);
                
                var responseExpenseCategory = new ExpenseCategoryDto
                {
                    ExpenseCategoryId = expenseCategory.ExpenseCategoryId,
                    CategoryExpenseName = expenseCategory.CategoryExpenseName
                };

                return Created("api/ExpenseCategory/" + expenseCategory.ExpenseCategoryId, responseExpenseCategory);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }
    }
}
