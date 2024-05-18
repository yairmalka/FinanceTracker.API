using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingGoalController : ControllerBase
    {
        private readonly ISavingGoalRepository savingGoalRepository;

        public SavingGoalController(ISavingGoalRepository savingGoalRepository)
        {
            this.savingGoalRepository = savingGoalRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSavingGoalAsync()
        {
            try
            {
                var response = await savingGoalRepository.GetAllSavingGoalAsync();
                var savingGoals = new List<SavingGoalDto>();
                foreach (var savingGoal in response)
                {
                    savingGoals.Add(new SavingGoalDto(savingGoal));
                }

                return Ok(savingGoals);
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }


        [HttpPost]
        public async Task<IActionResult> AddSavingGoalAsync(AddSavingGoalDto request)
        {
            var savingGoal = new SavingGoal
            {
                GoalName = request.GoalName,
                TargetAmount = request.TargetAmount,
                CurrentAmount = request.CurrentAmount,
                TargetDate = request.TargetDate
            };
        
            try
            {
               await savingGoalRepository.AddSavingGoalAsync(savingGoal);
                var savingGoalDtoResponse = new SavingGoalDto(savingGoal);

                return Created("api/income/" + savingGoalDtoResponse.GoalId, savingGoalDtoResponse);
            }

            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetSavingGoalByIdAsync(Guid id)
        {
            try
            {
                SavingGoal? response = await savingGoalRepository.GetSavingGoalByIdAsync(id);

                if (response == null)
                    return null;

                return Ok(new SavingGoalDto(response));
            }
        }
    }
}
