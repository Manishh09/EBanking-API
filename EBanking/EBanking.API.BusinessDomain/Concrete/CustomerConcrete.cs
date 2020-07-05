using EBanking.API.BusinessDomain.Interface;
using EBanking.API.Infrastructure;
using EBanking.API.Models;
using EBanking.API.Models.DomainModels;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EBanking.API.Shared.Constants;
using System;

namespace EBanking.API.BusinessDomain.Concrete
{
    public class CustomerConcrete : ICustomer
    {
        EBankingUnitOfWork _eBankingUnitOfWork;
        public CustomerConcrete(EBankingUnitOfWork eBankingUnitOfWork)
        {
            _eBankingUnitOfWork = eBankingUnitOfWork;
        }

        public async Task<List<CustomerViewModel>> GetDetails()
        {
            List<CustomerViewModel> response = new List<CustomerViewModel>();
            response = (from cd in _eBankingUnitOfWork.CustomerRepo.GetAll().Where(x=>x.RowStatusUid.Equals(Constants.RowStatusUid))
                        select new CustomerViewModel
                        {
                            CustomerId = cd.CustomerId,
                            CustomerUid = cd.CustomerUid,
                            EmailId = cd.EmailId,
                            Password = cd.Password,
                            RowStatusUid = cd.RowStatusUid

                            
                        }).ToList();
                        
            return response;
        }

        public bool SaveCustomerDetails(CustomerViewModel cust)
        {
            
            List<Customer> savecustomers = new List<Customer>();

            Customer customer = new Customer();
           var newEmailId = CustomerData(cust.EmailId).Count();
            if (newEmailId==0)
            {
                customer.EmailId = cust.EmailId;
                customer.Password = cust.Password;
                customer.RowStatusUid = Constants.RowStatusUid;
                savecustomers.Add(customer);                
            }
            else
            {
                // customer = _eBankingUnitOfWork.CustomerRepo.GetAll().Where(x=> x.EmailId == cust.EmailId && x.RowStatusUid).FirstOrDefault();
                customer = CustomerData(cust.EmailId).FirstOrDefault();
                customer.EmailId = cust.EmailId;
                customer.Password = cust.Password;               
                
            }
            _eBankingUnitOfWork.CustomerRepo.AddRange(savecustomers);
            return _eBankingUnitOfWork.SaveChanges();

        }

        public Guid ValidateCredentials(CustomerViewModel cust)
        {
           
            return _eBankingUnitOfWork.CustomerRepo.Get(x => x.EmailId == cust.EmailId && x.Password == cust.Password).FirstOrDefault().CustomerUid;
         
        }

        public bool ValidateNotExistingEmailId(string emailId)
        {
            return CustomerData(emailId).Count()>0;
          
        }
        private List<Customer> CustomerData(string emailId)
        {
            return _eBankingUnitOfWork.CustomerRepo.Get(x => x.EmailId== emailId && x.RowStatusUid.Equals(Constants.RowStatusUid)).ToList();
        }

    }
}
