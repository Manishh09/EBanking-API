using EBanking.API.BusinessDomain.Concrete;
using EBanking.API.Models.DomainModels;
using EBanking.API.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.BusinessDomain.Interface
{
    public interface INotification
    {
        List<NotificationViewModel> GetNotifications(Guid custguid);

        List<Notification> GetNotification();
    }
}
