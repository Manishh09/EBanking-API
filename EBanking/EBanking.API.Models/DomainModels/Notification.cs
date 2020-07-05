using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class Notification
    {
        public Guid NotificationUid { get; set; }
        public int NotificationId { get; set; }
        public Guid? CustomerUid { get; set; }
        public string Message { get; set; }
        public string Createdby { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? RowstatusUid { get; set; }

        public virtual Customer CustomerU { get; set; }
        public virtual RowStatus RowstatusU { get; set; }
    }
}
