using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.DTO
{
    public class AccountHistoryDTO
    {
        public decimal? Amount { get; set; }
        public DateTime? ChangedAt { get; set; }
    }
}
