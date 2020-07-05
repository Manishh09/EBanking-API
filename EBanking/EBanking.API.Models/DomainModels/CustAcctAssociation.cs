using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class CustAcctAssociation
    {
        public CustAcctAssociation()
        {
            TransactionData = new HashSet<TransactionData>();
        }

        public Guid CustAcctAssociationUid { get; set; }
        public int CustAcctAssociationId { get; set; }
        public string Name { get; set; }
        public long? Balance { get; set; }
        public DateTime OpenedOn { get; set; }
        public DateTime? ClosedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? CustomerUid { get; set; }
        public Guid? AccountsUid { get; set; }
        public Guid? RowStatusUid { get; set; }

        public virtual Accounts AccountsU { get; set; }
        public virtual Customer CustomerU { get; set; }
        public virtual RowStatus RowStatusU { get; set; }
        public virtual ICollection<TransactionData> TransactionData { get; set; }
    }
}
