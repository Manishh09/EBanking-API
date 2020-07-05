using EBanking.API.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace EBanking.API.Infrastructure.Repository
{
    public class CustAcctAssociationRepository : GenericRepository<CustAcctAssociation>
    {
        private readonly DbContext _context;
        public CustAcctAssociationRepository(DbContext context) : base(context)
        {
            _context = context;
        }
    }
}
