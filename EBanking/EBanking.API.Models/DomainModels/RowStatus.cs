using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class RowStatus
    {
        public RowStatus()
        {
            Accounts = new HashSet<Accounts>();
            Bank = new HashSet<Bank>();
            CustAcctAssociation = new HashSet<CustAcctAssociation>();
            Customer = new HashSet<Customer>();
            CustomerDetails = new HashSet<CustomerDetails>();
            Notification = new HashSet<Notification>();
            TransactionData = new HashSet<TransactionData>();
            TransactionType = new HashSet<TransactionType>();
        }

        public Guid RowStatusUid { get; set; }
        public int RowStatusId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<Bank> Bank { get; set; }
        public virtual ICollection<CustAcctAssociation> CustAcctAssociation { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual ICollection<CustomerDetails> CustomerDetails { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<TransactionData> TransactionData { get; set; }
        public virtual ICollection<TransactionType> TransactionType { get; set; }
    }
}
