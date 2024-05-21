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

                var responseExpenseCategory = new ExpenseCategoryDto(expenseCategory);

                return Created("api/ExpenseCategory/" + expenseCategory.ExpenseCategoryId, responseExpenseCategory);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpGet]
        public async Task<IActionResult> GetAllExpenseCategoriesAsync()
        {
            try
            {
                var expenseCategories = await expenseCategoryRepository.GetAllExpenseCategoriesAsync();
                var response = new List<ExpenseCategoryDto>();

                foreach (var expenseCategory in expenseCategories)
                {
                    response.Add(new ExpenseCategoryDto(expenseCategory));
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetExpenseCategoryByIdAsync(Guid id)
        {
            try
            {
                ExpenseCategory? response = await expenseCategoryRepository.GetExpenseCategoryByIdAsync(id);

                if (response == null)
                    return NotFound();


                return Ok(new ExpenseCategoryDto(response));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> EditExpenseCategory(Guid id, EditExpenseCategoryRequestDto request)
        {
                var expenseCategory = new ExpenseCategory
                {
                    ExpenseCategoryId = id,
                    CategoryExpenseName = request.CategoryExpenseName
                };
            try
            {
                var response = await expenseCategoryRepository.EditExpenseCategory(expenseCategory);

                if (response == null)
                    return NotFound();

                return Ok(new ExpenseCategoryDto(response));
            }

            catch(Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }
}
