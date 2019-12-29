using SimpleApiService.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Domain
{
    [Table("account_history")]
    public class AccountHistory
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("account_id")]
        public int AccountId { get; set; }

        [Column("amount")]
        public decimal? Amount { get; set; }

        [Column("changed_at")]
        public DateTime? ChangedAt { get; set; }

        [Column("type")]
        public OperationType Type { get; set; }
    }
}
