﻿using FinanceTracker.API.Models.Domain;
using FinanceTracker.API.Models.DTO;
using FinanceTracker.API.Repositories.Implementation;
using FinanceTracker.API.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.Common;

namespace FinanceTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeRepository incomeRepository;

        public IncomeController(IIncomeRepository incomeRepository)
        {
            this.incomeRepository = incomeRepository;
        }

        [HttpPost]
        public async Task<IActionResult> AddIncome(AddIncomeRequestDto request)
        {

            Income income = new Income
            {
                UserId = request.UserId,
                Source = request.Source,
                Amount = request.Amount,
                Frequency = request.Frequency,
                DateReceived = request.DateReceived,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status,
                Notes = request.Notes
            };
            try
            {
                await incomeRepository.AddIncomeAsync(income);
                var incomeDtoResponse = new IncomeDto(income);
                return Created("api/Income/" + incomeDtoResponse.IncomeId, incomeDtoResponse);
            }

            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIncomesAsync()
        {
            try
            {
                var incomes = await incomeRepository.GetAllIncomesAsync();
                var response = new List<IncomeDto>();

                foreach(var income in incomes)
                {
                    response.Add(new IncomeDto(income));
                }
                return Ok(response);
            }

            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                    }
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetIncomeByIdAsync(Guid id)
        {
            try
            {
                Income? response = await incomeRepository.GetIncomeByIdAsync(id);

                if (response == null)
                    return NotFound();

                return Ok(new IncomeDto(response));
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> EditIncome(Guid id, EditIncomeRequestDto request)
        {
            var income = new Income
            {
                IncomeId = id,
                Source = request.Source,
                Amount = request.Amount,
                Frequency = request.Frequency,
                DateReceived = request.DateReceived,
                PaymentMethod = request.PaymentMethod,
                Status = request.Status,
                Notes = request.Notes
            };

            income = await incomeRepository.EditIncome(income);

            if (income == null)
                return NotFound();

            return Ok(new IncomeDto(income));
    }

    }


}
