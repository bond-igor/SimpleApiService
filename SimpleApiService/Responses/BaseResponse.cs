using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Responses
{
    public class BaseResponse
    {
        public string Status { get; set; }

        public BaseResponse(string status)
        {
            Status = status;
        }
    }
}
