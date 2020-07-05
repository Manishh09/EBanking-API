using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EBanking.API.BusinessDomain.Interface;
using EBanking.API.Infrastructure;
using EBanking.API.Models.DomainModels;
using EBanking.API.Models.ViewModels;
using EBanking.API.Shared;
using EBanking.API.Shared.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EBanking.API.Serive.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        EBankingUnitOfWork _eBankingUnitOfWork;
        INotification _notification;

        public NotificationController(EBankingUnitOfWork eBankingUnitOfWork, INotification notification)
        {
            _eBankingUnitOfWork = eBankingUnitOfWork;
            _notification = notification;
        }


        [HttpGet("GetNotifications/{customerUid}")]
        public  IActionResult GetNotificaiton(Guid customerUid)
        {
            SingleResponse<List<NotificationViewModel>> response = new SingleResponse<List<NotificationViewModel>>();

            try
            {
                response.Model = _notification.GetNotifications(customerUid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response.ToHttpResponse();
        }
        [HttpGet("GetNotification")]
        public IActionResult GetNotification()
        {
            SingleResponse<List<Notification>> response = new SingleResponse<List<Notification>>();

            try
            {
                response.Model = _notification.GetNotification();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return response.ToHttpResponse();
        }
    }
}