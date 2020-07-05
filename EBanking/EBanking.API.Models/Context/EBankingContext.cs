using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EBanking.API.Models.DomainModels;

namespace EBanking.API.Models.Context
{
    public partial class EBankingContext : DbContext
    {
        public EBankingContext()
        {
        }

        public EBankingContext(DbContextOptions<EBankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Bank> Bank { get; set; }
        public virtual DbSet<CustAcctAssociation> CustAcctAssociation { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerDetails> CustomerDetails { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<RowStatus> RowStatus { get; set; }
        public virtual DbSet<TransactionData> TransactionData { get; set; }
        public virtual DbSet<TransactionType> TransactionType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=yourservername;Database=yourdbname;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>(entity =>
            {
                entity.HasKey(e => e.AccountsUid)
                    .HasName("PK__Accounts__A81F41026648CE18");

                entity.Property(e => e.AccountsUid)
                    .HasColumnName("AccountsUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AccountsId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustomerUid).HasColumnName("CustomerUId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.HasOne(d => d.CustomerU)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerUid)
                    .HasConstraintName("FK__Accounts__Custom__1F98B2C1");

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__Accounts__RowSta__208CD6FA");
            });

            modelBuilder.Entity<Bank>(entity =>
            {
                entity.HasKey(e => e.BankUid)
                    .HasName("PK__Bank__0CC32528BCC29F3B");

                entity.Property(e => e.BankUid)
                    .HasColumnName("BankUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BankId).ValueGeneratedOnAdd();

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.Bank)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__Bank__RowStatusU__32AB8735");
            });

            modelBuilder.Entity<CustAcctAssociation>(entity =>
            {
                entity.HasKey(e => e.CustAcctAssociationUid)
                    .HasName("PK__CustAcct__4919AB8D3136E42B");

                entity.Property(e => e.CustAcctAssociationUid)
                    .HasColumnName("CustAcctAssociationUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.AccountsUid).HasColumnName("AccountsUId");

                entity.Property(e => e.ClosedOn).HasColumnType("datetime");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustAcctAssociationId).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerUid).HasColumnName("CustomerUId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OpenedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.HasOne(d => d.AccountsU)
                    .WithMany(p => p.CustAcctAssociation)
                    .HasForeignKey(d => d.AccountsUid)
                    .HasConstraintName("FK__CustAcctA__Accou__2A164134");

                entity.HasOne(d => d.CustomerU)
                    .WithMany(p => p.CustAcctAssociation)
                    .HasForeignKey(d => d.CustomerUid)
                    .HasConstraintName("FK__CustAcctA__Custo__29221CFB");

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.CustAcctAssociation)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__CustAcctA__RowSt__2B0A656D");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerUid)
                    .HasName("PK__Customer__9FE189A3554CD05F");

                entity.Property(e => e.CustomerUid)
                    .HasColumnName("CustomerUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustomerId).ValueGeneratedOnAdd();

                entity.Property(e => e.EmailId).HasMaxLength(200);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__Customer__RowSta__07C12930");
            });

            modelBuilder.Entity<CustomerDetails>(entity =>
            {
                entity.HasKey(e => e.CustomerDetailsUid)
                    .HasName("PK__Customer__34ED7B761F1AE4AC");

                entity.Property(e => e.CustomerDetailsUid)
                    .HasColumnName("CustomerDetailsUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustomerDetailsId).ValueGeneratedOnAdd();

                entity.Property(e => e.CustomerUid).HasColumnName("CustomerUId");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.HasOne(d => d.CustomerU)
                    .WithMany(p => p.CustomerDetails)
                    .HasForeignKey(d => d.CustomerUid)
                    .HasConstraintName("FK__CustomerD__Custo__0F624AF8");

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.CustomerDetails)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__CustomerD__RowSt__10566F31");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.NotificationUid)
                    .HasName("PK__Notifica__8CA9AD89B6CC8B06");

                entity.Property(e => e.NotificationUid)
                    .HasColumnName("NotificationUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("createdOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Createdby)
                    .HasColumnName("createdby")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CustomerUid).HasColumnName("customerUId");

                entity.Property(e => e.Message).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .HasColumnName("modifiedBy")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnName("modifiedOn")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NotificationId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.CustomerU)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.CustomerUid)
                    .HasConstraintName("FK__Notificat__custo__73852659");

                entity.HasOne(d => d.RowstatusU)
                    .WithMany(p => p.Notification)
                    .HasForeignKey(d => d.RowstatusUid)
                    .HasConstraintName("FK__Notificat__Rowst__7849DB76");
            });

            modelBuilder.Entity<RowStatus>(entity =>
            {
                entity.HasKey(e => e.RowStatusUid)
                    .HasName("PK__RowStatu__FF70652EE684FFC4");

                entity.Property(e => e.RowStatusUid)
                    .HasColumnName("RowStatusUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowStatusId).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TransactionData>(entity =>
            {
                entity.HasKey(e => e.TransactionUid)
                    .HasName("PK__Transact__83C1FB8622B531C7");

                entity.Property(e => e.TransactionUid)
                    .HasColumnName("TransactionUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.BankUid).HasColumnName("BankUId");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.CustAcctAssociationUid).HasColumnName("CustAcctAssociationUId");

                entity.Property(e => e.CustomerUid).HasColumnName("CustomerUId");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.Property(e => e.Time)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.TransactionId).ValueGeneratedOnAdd();

                entity.Property(e => e.TransactionTypeUid).HasColumnName("TransactionTypeUId");

                entity.HasOne(d => d.BankU)
                    .WithMany(p => p.TransactionData)
                    .HasForeignKey(d => d.BankUid)
                    .HasConstraintName("FK__Transacti__BankU__498EEC8D");

                entity.HasOne(d => d.CustAcctAssociationU)
                    .WithMany(p => p.TransactionData)
                    .HasForeignKey(d => d.CustAcctAssociationUid)
                    .HasConstraintName("FK__Transacti__CustA__47A6A41B");

                entity.HasOne(d => d.CustomerU)
                    .WithMany(p => p.TransactionData)
                    .HasForeignKey(d => d.CustomerUid)
                    .HasConstraintName("FK__Transacti__Custo__489AC854");

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.TransactionData)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__Transacti__RowSt__4A8310C6");

                entity.HasOne(d => d.TransactionTypeU)
                    .WithMany(p => p.TransactionData)
                    .HasForeignKey(d => d.TransactionTypeUid)
                    .HasConstraintName("FK__Transacti__Trans__4B7734FF");
            });

            modelBuilder.Entity<TransactionType>(entity =>
            {
                entity.HasKey(e => e.TransactionTypeUid)
                    .HasName("PK__Transact__6B7266F825961C8C");

                entity.Property(e => e.TransactionTypeUid)
                    .HasColumnName("TransactionTypeUId")
                    .HasDefaultValueSql("(newsequentialid())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("('SYSTEM')");

                entity.Property(e => e.ModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RowStatusUid).HasColumnName("RowStatusUId");

                entity.Property(e => e.TransactionTypeId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.RowStatusU)
                    .WithMany(p => p.TransactionType)
                    .HasForeignKey(d => d.RowStatusUid)
                    .HasConstraintName("FK__Transacti__RowSt__17F790F9");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
