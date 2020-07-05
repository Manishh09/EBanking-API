using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class TransactionData
    {
        public Guid TransactionUid { get; set; }
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public long? Amount { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Time { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? CustAcctAssociationUid { get; set; }
        public Guid? CustomerUid { get; set; }
        public Guid? BankUid { get; set; }
        public Guid? RowStatusUid { get; set; }
        public Guid? TransactionTypeUid { get; set; }
        public Guid TransactorAcctAssociationUid { get; set; }

        public virtual Bank BankU { get; set; }
        public virtual CustAcctAssociation CustAcctAssociationU { get; set; }
        public virtual Customer CustomerU { get; set; }
        public virtual RowStatus RowStatusU { get; set; }
        public virtual TransactionType TransactionTypeU { get; set; }
    }
}
