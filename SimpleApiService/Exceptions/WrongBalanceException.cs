using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Exceptions
{
    public class WrongBalanceException : Exception
    {
        public WrongBalanceException(string message) : base(message)
        {
        }
    }
}
