using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EBanking.API.BusinessDomain.Interface;
using EBanking.API.Infrastructure;
using EBanking.API.Models.DomainModels;
using EBanking.API.Shared;
using EBanking.API.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBanking.API.Serive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        EBankingUnitOfWork _eBankingUnitOfWork;
        ICustomer _customer;
        public CustomerController(EBankingUnitOfWork eBankingUnitOfWork, ICustomer customer)
        {
            _eBankingUnitOfWork = eBankingUnitOfWork;
            _customer = customer;
        }

        [HttpGet("GetDetails")]
        public async  Task<IActionResult> GetDetails()
        {
          SingleResponse<List<CustomerViewModel>> response= new SingleResponse<List<CustomerViewModel>>();
            try
            {
                response.Model = await _customer.GetDetails();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response.ToHttpResponse();
        }

        [HttpPost("ValidateCredentials")]
        public async Task<IActionResult> ValidateExistingEmailId(CustomerViewModel cust)
        {
         SingleResponse<Guid> response= new SingleResponse<Guid>();
           try
           {
               response.Model =  _customer.ValidateCredentials(cust);
           }
           catch(Exception ex)
           {
               throw ex;
           }
           return response.ToHttpResponse();
        }

        [HttpGet("ValidateNotExistingEmailId/{emailId}")]
        public async Task<IActionResult> ValidateNotExistingEmailId(string emailId)
        {
            SingleResponse<bool> response = new SingleResponse<bool>();
            try
            {
                response.Model = _customer.ValidateNotExistingEmailId(emailId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response.ToHttpResponse();
        }

        [HttpPost("Save")]
        public async Task<IActionResult> SaveCustomerDetails(CustomerViewModel cust)
        {
            SingleResponse<bool> response = new SingleResponse<bool>();
            
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                response.Model =   _customer.SaveCustomerDetails(cust);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response.ToHttpResponse();
        }
    }
}