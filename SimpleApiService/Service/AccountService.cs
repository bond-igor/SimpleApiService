using Microsoft.EntityFrameworkCore;
using SimpleApiService.Domain.Context;
using SimpleApiService.Domain.Enums;
using SimpleApiService.DTO;
using SimpleApiService.Exceptions;
using SimpleApiService.Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace SimpleApiService.Service
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationContext _Сontext;
        private readonly IAccountHistoryService _AccountHistoryService;

        public AccountService(ApplicationContext context, IAccountHistoryService accountHistoryService)
        {
            _Сontext = context;
            _AccountHistoryService = accountHistoryService;
        }

        public async Task<decimal> TopUp(int accountId, decimal amount)
        {
            if (amount < 0)
            {
                throw new WrongParamsException("Ошибка параметра");
            }

            var account = await _Сontext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);

            if (account == null)
            {
                throw new NotFoundException("Запись не найдена");
            }

            account.Balance += amount;

            await _Сontext.SaveChangesAsync();
            await _AccountHistoryService.AddHistory(accountId, amount, OperationType.Deposit);

            return account.Balance;
        }

        public async Task<decimal> Withdraw(int accountId, decimal amount)
        {
            if (amount < 0)
            {
                throw new WrongParamsException("Ошибка параметра");
            }

            var account = await _Сontext.Accounts.FirstOrDefaultAsync(x => x.Id == accountId);

            if (account == null)
            {
                throw new NotFoundException("Запись не найдена");
            }

            account.Balance -= amount;

            if (account.Balance < 0)
            {
                throw new WrongBalanceException("Ошибка в итоговом балансе");
            }

            await _Сontext.SaveChangesAsync();
            await _AccountHistoryService.AddHistory(accountId, amount, OperationType.Withdraw);

            return account.Balance;
        }

        public async Task<TransferDTO> Transfer(int sourceAccountId, int destinationAccountId, decimal amount)
        {
            if (amount < 0)
            {
                throw new WrongParamsException("Ошибка параметра");
            }

            var accountTo = await _Сontext.Accounts.FirstOrDefaultAsync(x => x.Id == sourceAccountId);
            var accountFrom = await _Сontext.Accounts.FirstOrDefaultAsync(x => x.Id == destinationAccountId);

            if (accountTo == null || accountFrom == null)
            {
                throw new NotFoundException("Запись не найдена");
            }

            accountTo.Balance += amount;
            accountFrom.Balance -= amount;

            if (accountTo.Balance < 0 || accountFrom.Balance < 0)
            {
                throw new WrongBalanceException("Ошибка в итоговом балансе");
            }

            await _AccountHistoryService.AddHistory(accountTo.Id, amount, OperationType.Deposit);
            await _AccountHistoryService.AddHistory(accountFrom.Id, amount, OperationType.Withdraw);

            return new TransferDTO
            {
                SourceBalance = accountFrom.Balance,
                DestinationBalance = accountTo.Balance
            };
        }
    }
}
