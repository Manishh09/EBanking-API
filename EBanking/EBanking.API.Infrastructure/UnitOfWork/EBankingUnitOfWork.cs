using EBanking.API.Infrastructure.Repository;
using EBanking.API.Models.Context;

namespace EBanking.API.Infrastructure
{
    public class EBankingUnitOfWork : UnitOfWork
    {
        public EBankingUnitOfWork(EBankingContext context) : base(context)
        {
            
        }
        public AccountsRepository AccountsRepo
        {
            get
            {
                return new AccountsRepository(_context);
            }
        }
        public BankRepository BankRepo
        {
            get
            {
                return new BankRepository(_context);
            }
        }
        public CustomerRepository CustomerRepo
        {
            get
            {
                return new CustomerRepository(_context);
            }
        }
        public CustomerDetailsRepository CustomerDetailsRepo
        {
            get
            {
                return new CustomerDetailsRepository(_context);
            }
        }
        public CustAcctAssociationRepository CustAcctAssociationRepo
        {
            get
            {
                return new CustAcctAssociationRepository(_context);
            }
        }

        public NotificationRepository NotificationRepo
        {
            get
            {
                return new NotificationRepository(_context);
            }
        }
        public RowStatusRepository RowStatusRepo
        {
            get
            {
                return new RowStatusRepository(_context);
            }
        }
        public TransactionDataRepository TransactionDataRepo
        {
            get
            {
                return new TransactionDataRepository(_context);
            }
        }
        public TransactionTypeRepository TransactionTypeRepo
        {
            get
            {
                return new TransactionTypeRepository(_context);
            }
        }
      
    }
}
