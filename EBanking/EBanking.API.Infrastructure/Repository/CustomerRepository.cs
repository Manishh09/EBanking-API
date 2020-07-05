using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure.Repository
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        private readonly DbContext _context;
        public CustomerRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
