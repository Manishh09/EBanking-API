using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Shared.Response
{
        public class ListResponse<TModel> : IListResponse<TModel>
        {
            public ListResponse()
            {
                IsValid = true;
            }
            public string Message { get; set; }

            public bool DidError { get; set; }

            public bool IsValid { get; set; }

            public string ErrorMessage { get; set; }

            public IEnumerable<TModel> Model { get; set; }
        }
    
}
