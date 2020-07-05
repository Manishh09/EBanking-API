using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Shared
{
    public interface IResponse
    {
        string Message { get; set; }
        bool DidError { get; set; }

        bool IsValid { get; set; }
        string ErrorMessage { get; set; }
    }
}
