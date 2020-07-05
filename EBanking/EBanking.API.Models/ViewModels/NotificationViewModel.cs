using System;
using System.Collections.Generic;
using System.Text;

namespace EBanking.API.Models.ViewModels
{
    public class NotificationViewModel
    {
        public Guid NotificationUid { get; set; }
        public int NotificationId { get; set; }
        public Guid? CustomerUid { get; set; }
        public string Message { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedOn { get; set; }

        public Guid? RowStatusUid { get; set; }
    }
}
