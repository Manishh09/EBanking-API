using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Infrastructure.Repository
{
    public class AccountsRepository : GenericRepository<Accounts>
    {
        private readonly DbContext _context;
        public AccountsRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
