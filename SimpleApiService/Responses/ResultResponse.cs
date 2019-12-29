using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Responses
{
    public class ResultResponse : BaseResponse
    {
        public Object Result { get; set; }

        public ResultResponse(string status, object result) : base(status)
        {
            Result = result;
        }
    }
}
