using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Domain
{
    [Table("account")]
    public class Account
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("account_number")]
        public string AccountNumber { get; set; }

        [Column("balance")]
        public decimal Balance { get; set; }
    }
}
