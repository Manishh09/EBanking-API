using System;
using System.Collections.Generic;
using System.Text;
using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure.Repository
{
    public class TransactionDataRepository : GenericRepository<TransactionData>
    {
        private readonly DbContext _context;
        public TransactionDataRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
