using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Infrastructure.Repository
{
    public class BankRepository : GenericRepository<Bank>
    {
        private readonly DbContext _context;
        public BankRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
