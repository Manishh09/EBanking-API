using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Shared.Response
{
    interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
