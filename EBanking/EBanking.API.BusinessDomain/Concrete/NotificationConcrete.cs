using EBanking.API.BusinessDomain.Interface;
using EBanking.API.Infrastructure;
using EBanking.API.Models.ViewModels;
using EBanking.API.Shared.Constants;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using EBanking.API.Models.DomainModels;

namespace EBanking.API.BusinessDomain.Concrete
{
    public class NotificationConcrete : INotification
    {
        EBankingUnitOfWork _eBankingUnitOfWork;


        public NotificationConcrete(EBankingUnitOfWork eBankingUnitOfWork)
        {
            _eBankingUnitOfWork = eBankingUnitOfWork;
        }
        public List<Notification> GetNotification()
        {
            return _eBankingUnitOfWork.NotificationRepo.Get(x => x.RowstatusUid.Equals(Constants.RowStatusUid)).ToList();
        }

        public List<NotificationViewModel> GetNotifications(Guid custguid)
        {
            List<NotificationViewModel> model = new List<NotificationViewModel>();

            model = (from nt in _eBankingUnitOfWork.NotificationRepo.GetAll().Where(x => x.CustomerUid.Equals(custguid) && x.RowstatusUid.Equals(Constants.RowStatusUid))
                     select new NotificationViewModel
                     {
                         CustomerUid = nt.CustomerUid,
                         Message = nt.Message,
                         NotificationId = nt.NotificationId,
                         NotificationUid = nt.NotificationUid,
                         Createdby = nt.Createdby,
                         CreatedOn = nt.CreatedOn

                     }).ToList();

            return model;
        }
    }
}
