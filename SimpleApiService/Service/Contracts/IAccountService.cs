using SimpleApiService.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Service.Contracts
{
    public interface IAccountService
    {
        /// <summary>
        /// Депозит дс
        /// </summary>
        public Task<decimal> TopUp(int accountId, decimal amount);

        /// <summary>
        /// Снять дс
        /// </summary>
        public Task<decimal> Withdraw(int accountId, decimal amount);

        /// <summary>
        /// Трансфер дс между счетами
        /// </summary>
        public Task<TransferDTO> Transfer(int sourceAccountId, int destinationAccountId, decimal amount);
    }
}
