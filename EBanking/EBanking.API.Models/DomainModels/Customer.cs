using System;
using System.Collections.Generic;

namespace EBanking.API.Models.DomainModels
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Accounts>();
            CustAcctAssociation = new HashSet<CustAcctAssociation>();
            CustomerDetails = new HashSet<CustomerDetails>();
            Notification = new HashSet<Notification>();
            TransactionData = new HashSet<TransactionData>();
        }

        public Guid CustomerUid { get; set; }
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public Guid? RowStatusUid { get; set; }
        public string EmailId { get; set; }

        public virtual RowStatus RowStatusU { get; set; }
        public virtual ICollection<Accounts> Accounts { get; set; }
        public virtual ICollection<CustAcctAssociation> CustAcctAssociation { get; set; }
        public virtual ICollection<CustomerDetails> CustomerDetails { get; set; }
        public virtual ICollection<Notification> Notification { get; set; }
        public virtual ICollection<TransactionData> TransactionData { get; set; }
    }
}
