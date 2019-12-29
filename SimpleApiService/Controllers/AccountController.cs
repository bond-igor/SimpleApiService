using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleApiService.Domain;
using SimpleApiService.Domain.Context;
using SimpleApiService.DTO;
using SimpleApiService.DTO.Constants;
using SimpleApiService.Exceptions;
using SimpleApiService.Requests;
using SimpleApiService.Responses;
using SimpleApiService.Service.Contracts;

namespace SimpleApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _AccountService;
        private readonly IAccountHistoryService _AccountHistoryService;

        public AccountController(IAccountService accountService, IAccountHistoryService accountHistoryService)
        {
            _AccountService = accountService;
            _AccountHistoryService = accountHistoryService;
        }

        [HttpGet("{accountId}/history")]
        public async Task<IActionResult> Get([FromRoute] int accountId)
        {
            try
            {
                var result = await _AccountHistoryService.GetAccountHistorys(accountId);

                return Ok(new ResultResponse(StatusConstants.Ok, result));
            }
            catch (NotFoundException e)
            {
                return NotFound(new ErrorResponse(StatusConstants.Error, e.Message));
            }
        }
        
        [HttpPost("{accountId}/top-up")]
        public async Task<IActionResult> TopUp([FromRoute] int accountId, [FromBody] AmountRequest model)
        {
            try
            {
                var result = await _AccountService.TopUp(accountId, model.Amount);

                return Ok(new ResultResponse(StatusConstants.Ok, result));
            }
            catch (NotFoundException e)
            {
                return NotFound(new ErrorResponse(StatusConstants.Error, e.Message));
            }
            catch (WrongParamsException e)
            {
                return BadRequest(new ErrorResponse(StatusConstants.Error, e.Message));
            }
        }

        [HttpPost("{accountId}/withdraw")]
        public async Task<IActionResult> Withdraw([FromRoute] int accountId, [FromBody] AmountRequest model)
        {
            try
            {
                var result = await _AccountService.Withdraw(accountId, model.Amount);

                return Ok(new ResultResponse(StatusConstants.Ok, result));
            }
            catch (NotFoundException e)
            {
                return NotFound(new ErrorResponse(StatusConstants.Error, e.Message));
            }
            catch (WrongParamsException e)
            {
                return BadRequest(new ErrorResponse(StatusConstants.Error, e.Message));
            }
            catch (WrongBalanceException e)
            {
                return Ok(new ErrorResponse(StatusConstants.Error, e.Message));
            }
        }

        [HttpPost("{sourceAccountId}/transfer/{destinationAccountId}")]
        public async Task<IActionResult> Transfer([FromRoute] int sourceAccountId, [FromRoute] int destinationAccountId, [FromBody] AmountRequest model)
        {
            try
            {
                var result = await _AccountService.Transfer(sourceAccountId, destinationAccountId, model.Amount);

                return Ok(new ResultResponse(StatusConstants.Ok, result));
            }
            catch (NotFoundException e)
            {
                return NotFound(new ErrorResponse(StatusConstants.Error, e.Message));
            }
            catch (WrongParamsException e)
            {
                return BadRequest(new ErrorResponse(StatusConstants.Error, e.Message));
            }
            catch (WrongBalanceException e)
            {
                return Ok(new ErrorResponse(StatusConstants.Error, e.Message));
            }
        }
    }
}