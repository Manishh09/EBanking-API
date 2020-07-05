using EBanking.API.Models.Context;
using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Infrastructure.Repository
{
    public class NotificationRepository : GenericRepository<Notification>
    {

        private readonly DbContext _context;
        public NotificationRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
