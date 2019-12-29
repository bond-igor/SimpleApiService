using SimpleApiService.Domain.Enums;
using SimpleApiService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Service.Contracts
{
    public interface IAccountHistoryService 
    {
        /// <summary>
        /// Список историй по id аккаунта
        /// </summary>
        Task<IEnumerable<AccountHistoryDTO>> GetAccountHistorys(int accountId);

        /// <summary>
        /// Добавляет запись истории в бд
        /// </summary>
        Task AddHistory(int accountId, decimal amount, OperationType type);
    }
}
