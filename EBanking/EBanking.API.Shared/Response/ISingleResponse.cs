using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Shared
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
