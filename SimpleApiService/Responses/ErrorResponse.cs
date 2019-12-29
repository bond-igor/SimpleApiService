using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Responses
{
    public class ErrorResponse : BaseResponse
    {
        public String ErrorMsg { get; set; }

        public ErrorResponse(string status, string errorMsg) : base(status)
        {
            ErrorMsg = errorMsg;
        }
    }
}
