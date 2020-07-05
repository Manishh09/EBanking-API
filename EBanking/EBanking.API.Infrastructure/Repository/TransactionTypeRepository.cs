using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure.Repository
{
    public class TransactionTypeRepository : GenericRepository<TransactionType>
    {
        private readonly DbContext _context;
        public TransactionTypeRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
