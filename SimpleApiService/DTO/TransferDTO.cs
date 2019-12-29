using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.DTO
{
    public class TransferDTO
    {
        public decimal SourceBalance { get; set; }
        public decimal DestinationBalance { get; set; }
    }
}
