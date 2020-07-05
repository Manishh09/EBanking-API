using System;
using System.Collections.Generic;
using System.Text;
using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure.Repository
{
    public class RowStatusRepository : GenericRepository <RowStatus>
    {
        private readonly DbContext _context;
        public RowStatusRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
