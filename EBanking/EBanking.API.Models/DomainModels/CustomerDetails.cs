using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class CustomerDetails
    {
        public Guid CustomerDetailsUid { get; set; }
        public int CustomerDetailsId { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? CustomerUid { get; set; }
        public Guid? RowStatusUid { get; set; }
        public string Name { get; set; }
        public long Mobile { get; set; }

        public virtual Customer CustomerU { get; set; }
        public virtual RowStatus RowStatusU { get; set; }
    }
}
