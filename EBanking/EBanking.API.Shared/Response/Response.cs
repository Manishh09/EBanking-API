﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Shared.Response
{
    public class Response : IResponse
    {
        public Response()
        {
            IsValid = true;
        }
        public string Message { get; set; }
        public bool DidError { get; set; }

        public bool IsValid { get; set; }
        public string ErrorMessage { get; set; }
    }
}
