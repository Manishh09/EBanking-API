using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure.Repository
{
    public class CustomerDetailsRepository : GenericRepository<CustomerDetails>
    {
        private readonly DbContext _context;
        public CustomerDetailsRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
