using EBanking.API.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EBanking.API.BusinessDomain.Interface
{
    public interface ICustomer
    {
        Task<List<CustomerViewModel>> GetDetails();
        
        bool SaveCustomerDetails(CustomerViewModel cust);

        Guid ValidateCredentials(CustomerViewModel cust);

        bool ValidateNotExistingEmailId(string emailId);
    }
}
