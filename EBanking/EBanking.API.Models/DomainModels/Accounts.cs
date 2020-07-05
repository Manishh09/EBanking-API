using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class Accounts
    {
        public Accounts()
        {
            CustAcctAssociation = new HashSet<CustAcctAssociation>();
        }

        public Guid AccountsUid { get; set; }
        public int AccountsId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? CustomerUid { get; set; }
        public Guid? RowStatusUid { get; set; }

        public virtual Customer CustomerU { get; set; }
        public virtual RowStatus RowStatusU { get; set; }
        public virtual ICollection<CustAcctAssociation> CustAcctAssociation { get; set; }
    }
}
