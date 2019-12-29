using Microsoft.EntityFrameworkCore;
using SimpleApiService.Domain;
using SimpleApiService.Domain.Context;
using SimpleApiService.Domain.Enums;
using SimpleApiService.DTO;
using SimpleApiService.Exceptions;
using SimpleApiService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Service
{
    public class AccountHistoryService : IAccountHistoryService
    {
        private readonly ApplicationContext _Context;

        public AccountHistoryService(ApplicationContext context)
        {
            _Context = context;
        }
                
        public async Task<IEnumerable<AccountHistoryDTO>> GetAccountHistorys(int accountId)
        {
            var historys = await _Context.AccountHistorys
               .Where(x => x.AccountId == accountId)
               .Select(x =>
                   new AccountHistoryDTO
                   {
                       Amount = x.Amount,
                       ChangedAt = x.ChangedAt
                   })
               .OrderByDescending(x => x.ChangedAt)
               .ToListAsync();

            if (!historys.Any())
                throw new NotFoundException("Записи не найдены");

            return historys;
        }
                
        public async Task AddHistory(int accountId, decimal amount, OperationType type)
        {
            var history = new AccountHistory
            {
                AccountId = accountId,
                Amount = amount,
                ChangedAt = DateTime.Now,
                Type = type
            };

            await _Context.AccountHistorys.AddAsync(history);
            await _Context.SaveChangesAsync();
        }
    }
}
