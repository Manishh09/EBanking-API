using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class CustomerViewModel
    {
        

        public Guid CustomerUid { get; set; }
        public int CustomerId { get; set; }
        public string Password { get; set; }
        //public string CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string ModifiedBy { get; set; }
        //public DateTime ModifiedOn { get; set; }
        public Guid? RowStatusUid { get; set; }
        public string EmailId { get; set; }

        
    }
}
