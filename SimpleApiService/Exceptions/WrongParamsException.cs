﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleApiService.Exceptions
{
    public class WrongParamsException : Exception
    {
        public WrongParamsException(string message) : base(message)
        {
        }
    }
}
