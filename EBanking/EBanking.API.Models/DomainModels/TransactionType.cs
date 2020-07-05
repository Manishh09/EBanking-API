using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class TransactionType
    {
        public TransactionType()
        {
            TransactionData = new HashSet<TransactionData>();
        }

        public Guid TransactionTypeUid { get; set; }
        public int TransactionTypeId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? RowStatusUid { get; set; }

        public virtual RowStatus RowStatusU { get; set; }
        public virtual ICollection<TransactionData> TransactionData { get; set; }
    }
}
