using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {     
        bool SaveChanges();
    }
}
