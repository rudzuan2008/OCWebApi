using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CA.DAL.Models.MasjidKITA;

namespace CA.DAL;

public partial class CADbContext : DbContext
{
    public CADbContext(DbContextOptions<CADbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audit> Audits { get; set; }

    public virtual DbSet<Contactu> Contactus { get; set; }

    public virtual DbSet<Download> Downloads { get; set; }

    public virtual DbSet<Downloadcharge> Downloadcharges { get; set; }

    public virtual DbSet<Eghl> Eghls { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Month> Months { get; set; }

    public virtual DbSet<Mosquecoordinate> Mosquecoordinates { get; set; }

    public virtual DbSet<Mosqueinfo> Mosqueinfos { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Paymentgateway> Paymentgateways { get; set; }

    public virtual DbSet<Refcity> Refcities { get; set; }

    public virtual DbSet<Refcountry> Refcountries { get; set; }

    public virtual DbSet<Refgroupone> Refgroupones { get; set; }

    public virtual DbSet<Refpaymentstatus> Refpaymentstatuses { get; set; }

    public virtual DbSet<Refpaymenttype> Refpaymenttypes { get; set; }

    public virtual DbSet<Refprice> Refprices { get; set; }

    public virtual DbSet<Refstate> Refstates { get; set; }

    public virtual DbSet<Refsubscriptionstatus> Refsubscriptionstatuses { get; set; }

    public virtual DbSet<Refwebsitestatus> Refwebsitestatuses { get; set; }

    public virtual DbSet<Scheduler> Schedulers { get; set; }

    public virtual DbSet<Sysnotification> Sysnotifications { get; set; }

    public virtual DbSet<Tenant> Tenants { get; set; }

    public virtual DbSet<Tenantsubscription> Tenantsubscriptions { get; set; }

    public virtual DbSet<V1Aliaspartindex> V1Aliaspartindices { get; set; }

    public virtual DbSet<V1Autoroutepartindex> V1Autoroutepartindices { get; set; }

    public virtual DbSet<V1Containedpartindex> V1Containedpartindices { get; set; }

    public virtual DbSet<V1Contentitemindex> V1Contentitemindices { get; set; }

    public virtual DbSet<V1Deploymentplanindex> V1Deploymentplanindices { get; set; }

    public virtual DbSet<V1Document> V1Documents { get; set; }

    public virtual DbSet<V1Identifier> V1Identifiers { get; set; }

    public virtual DbSet<V1Indexingtask> V1Indexingtasks { get; set; }

    public virtual DbSet<V1Layermetadataindex> V1Layermetadataindices { get; set; }

    public virtual DbSet<V1Localizedcontentitemindex> V1Localizedcontentitemindices { get; set; }

    public virtual DbSet<V1Taxonomyindex> V1Taxonomyindices { get; set; }

    public virtual DbSet<V1Userbyclaimindex> V1Userbyclaimindices { get; set; }

    public virtual DbSet<V1Userbylogininfoindex> V1Userbylogininfoindices { get; set; }

    public virtual DbSet<V1Userbyrolenameindex> V1Userbyrolenameindices { get; set; }

    public virtual DbSet<V1UserbyrolenameindexDocument> V1UserbyrolenameindexDocuments { get; set; }

    public virtual DbSet<V1Userindex> V1Userindices { get; set; }

    public virtual DbSet<V1Workflowblockingactivitiesindex> V1Workflowblockingactivitiesindices { get; set; }

    public virtual DbSet<V1Workflowindex> V1Workflowindices { get; set; }

    public virtual DbSet<V1Workflowtypeindex> V1Workflowtypeindices { get; set; }

    public virtual DbSet<V1Workflowtypestartactivitiesindex> V1Workflowtypestartactivitiesindices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Audit>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("audit");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.AuditType).HasColumnType("int(11)");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.Method).HasMaxLength(60);
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .HasColumnName("UserID");
        });

        modelBuilder.Entity<Contactu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("contactus");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Inquiry).HasColumnType("text");
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.TicketId)
                .HasMaxLength(50)
                .HasColumnName("TicketID");
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Download>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("download");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Amount)
                .HasPrecision(10, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.Attachment).HasMaxLength(255);
            entity.Property(e => e.Chargeable).HasColumnType("tinyint(4)");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.DownloadCode).HasMaxLength(50);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(255);
            entity.Property(e => e.TotalDownload).HasColumnType("int(11)");
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        modelBuilder.Entity<Downloadcharge>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("downloadcharge");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Amount).HasPrecision(10, 2);
            entity.Property(e => e.Attachment).HasMaxLength(255);
            entity.Property(e => e.CodeSentStatus).HasColumnType("int(11)");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.DocId)
                .HasMaxLength(12)
                .HasColumnName("DocID");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PayStatus).HasMaxLength(255);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.RefId)
                .HasMaxLength(12)
                .HasColumnName("RefID");
        });

        modelBuilder.Entity<Eghl>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("eghl");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)");
            entity.Property(e => e.CurrencyCode).HasMaxLength(50);
            entity.Property(e => e.LanguageCode).HasMaxLength(50);
            entity.Property(e => e.MerchantCallBackUrl)
                .HasMaxLength(500)
                .HasColumnName("MerchantCallBackURL");
            entity.Property(e => e.MerchantName).HasMaxLength(255);
            entity.Property(e => e.MerchantReturnUrl)
                .HasMaxLength(500)
                .HasColumnName("MerchantReturnURL");
            entity.Property(e => e.PageTimeout).HasColumnType("int(11)");
            entity.Property(e => e.PymtMethod).HasMaxLength(255);
            entity.Property(e => e.ServiceId)
                .HasMaxLength(50)
                .HasColumnName("ServiceID");
            entity.Property(e => e.TransactionType).HasMaxLength(50);
            entity.Property(e => e.TxnStatus).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("feedback");

            entity.HasIndex(e => e.MemberId, "MemberID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CustEmail).HasMaxLength(50);
            entity.Property(e => e.CustName).HasMaxLength(50);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.FeedbackType).HasColumnType("int(11)");
            entity.Property(e => e.MemberId)
                .HasColumnType("int(10)")
                .HasColumnName("MemberID");
            entity.Property(e => e.MemberNo).HasMaxLength(50);
            entity.Property(e => e.Message).HasMaxLength(255);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.MsgFeedback).HasMaxLength(255);
            entity.Property(e => e.NonMemberNo).HasMaxLength(50);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.ResolveBy).HasMaxLength(50);
            entity.Property(e => e.ResolveStatus).HasColumnType("int(11)");
            entity.Property(e => e.Subject).HasMaxLength(255);
            entity.Property(e => e.TicketId)
                .HasMaxLength(50)
                .HasColumnName("TicketID");
        });

        modelBuilder.Entity<Month>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("month");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Mosquecoordinate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mosquecoordinates");

            entity.HasIndex(e => e.MosqId, "mosqID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("bit(1)");
            entity.Property(e => e.MosqId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'")
                .HasColumnName("mosqID");
        });

        modelBuilder.Entity<Mosqueinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("mosqueinfo");

            entity.HasIndex(e => e.City, "City");

            entity.HasIndex(e => e.Country, "Country");

            entity.HasIndex(e => e.State, "State");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.City).HasColumnType("int(11)");
            entity.Property(e => e.Country).HasColumnType("int(11)");
            entity.Property(e => e.CreatedBy).HasMaxLength(255);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Logo).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(255);
            entity.Property(e => e.MosqueId)
                .HasColumnType("int(11)")
                .HasColumnName("MosqueID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PhoneNo).HasMaxLength(50);
            entity.Property(e => e.Postcode).HasColumnType("int(11)");
            entity.Property(e => e.State).HasColumnType("int(11)");
            entity.Property(e => e.UserId)
                .HasMaxLength(50)
                .HasColumnName("UserID");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("payment");

            entity.HasIndex(e => e.FkPaymentId, "FK_PaymentID");

            entity.HasIndex(e => e.FkPriceId, "FK_PriceID");

            entity.HasIndex(e => e.PaymentStatus, "PaymentStatus");

            entity.HasIndex(e => e.SubscriptionStatus, "SubscriptionStatus");

            entity.HasIndex(e => e.TenantId, "TenantID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.Attachment)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.BankName).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FkPaymentId)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("FK_PaymentID");
            entity.Property(e => e.FkPriceId)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("FK_PriceID");
            entity.Property(e => e.InvoiceNo)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.IsRenewal)
                .HasDefaultValueSql("'0'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("isRenewal");
            entity.Property(e => e.ModifiedBy)
                .HasMaxLength(50)
                .HasDefaultValueSql("'\"\"'");
            entity.Property(e => e.MosqueAddress)
                .HasMaxLength(300)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MosqueId)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MosqueName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.OnlinePaymentId)
                .HasMaxLength(50)
                .HasColumnName("OnlinePaymentID");
            entity.Property(e => e.PaymentAmountRm)
                .HasPrecision(10, 2)
                .HasColumnName("PaymentAmountRM");
            entity.Property(e => e.PaymentMethods).HasMaxLength(50);
            entity.Property(e => e.PaymentStatus).HasColumnType("tinyint(4)");
            entity.Property(e => e.SubscribeEndDate).HasColumnType("datetime");
            entity.Property(e => e.SubscribeStartDate).HasColumnType("datetime");
            entity.Property(e => e.SubscriptionStatus).HasColumnType("tinyint(4)");
            entity.Property(e => e.TenantId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11) unsigned")
                .HasColumnName("TenantID");

            entity.HasOne(d => d.FkPayment).WithMany(p => p.Payments)
                .HasForeignKey(d => d.FkPaymentId)
                .HasConstraintName("FK_PaymentID");

            entity.HasOne(d => d.FkPrice).WithMany(p => p.Payments)
                .HasForeignKey(d => d.FkPriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PriceID");

            entity.HasOne(d => d.Tenant).WithMany(p => p.Payments)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK_payment_tenant");
        });

        modelBuilder.Entity<Paymentgateway>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("paymentgateway");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.ApiKey)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.CallbackUrl)
                .HasMaxLength(255)
                .HasColumnName("CallbackURL");
            entity.Property(e => e.CollectionId)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.Handle)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.MosqId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11)")
                .HasColumnName("MosqID");
            entity.Property(e => e.PayGatewayUrl)
                .HasMaxLength(255)
                .HasDefaultValueSql("'0'")
                .HasColumnName("PayGatewayURL");
            entity.Property(e => e.RedirectUrl)
                .HasMaxLength(255)
                .HasColumnName("RedirectURL");
        });

        modelBuilder.Entity<Refcity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refcity");

            entity.HasIndex(e => e.StateId, "StateID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.CityName).HasMaxLength(6553);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.StateId)
                .HasColumnType("int(11)")
                .HasColumnName("StateID");

            entity.HasOne(d => d.State).WithMany(p => p.Refcities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("StateID");
        });

        modelBuilder.Entity<Refcountry>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refcountry");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.CountryCode).HasMaxLength(50);
            entity.Property(e => e.CountryName).HasMaxLength(255);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
        });

        modelBuilder.Entity<Refgroupone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refgroupone");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(3) unsigned");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<Refpaymentstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refpaymentstatus");

            entity.HasIndex(e => e.Type, "Type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<Refpaymenttype>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refpaymenttype");

            entity.HasIndex(e => e.Type, "Type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<Refprice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refprice");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.ContentItemId).HasMaxLength(50);
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.CustomFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Description1).HasMaxLength(500);
            entity.Property(e => e.Description2).HasMaxLength(500);
            entity.Property(e => e.Description3).HasMaxLength(500);
            entity.Property(e => e.DiscountPrice).HasPrecision(10, 2);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.ImageName).HasMaxLength(2000);
            entity.Property(e => e.ImagePath).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.PackageName).HasMaxLength(50);
            entity.Property(e => e.Pautan).HasMaxLength(250);
            entity.Property(e => e.Price).HasColumnType("decimal(10,2) unsigned");
            entity.Property(e => e.PriceFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.TotalMember).HasColumnType("int(11)");
        });

        modelBuilder.Entity<Refstate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refstate");

            entity.HasIndex(e => e.CountryId, "CountryID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CountryId)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("CountryID");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.StateCode)
                .HasMaxLength(50)
                .HasDefaultValueSql("'0'");
            entity.Property(e => e.StateName).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Refstates)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("CountryID");
        });

        modelBuilder.Entity<Refsubscriptionstatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refsubscriptionstatus");

            entity.HasIndex(e => e.Type, "Type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<Refwebsitestatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("refwebsitestatus");

            entity.HasIndex(e => e.Type, "Type");

            entity.Property(e => e.Id)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasColumnType("tinyint(4)");
        });

        modelBuilder.Entity<Scheduler>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("scheduler");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.CronScheduler).HasMaxLength(500);
            entity.Property(e => e.DayTrigger).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.DurationType).HasColumnType("int(11)");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.Frequency).HasColumnType("int(11)");
            entity.Property(e => e.Handle).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(500);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TenantId)
                .HasMaxLength(50)
                .HasColumnName("TenantID");
            entity.Property(e => e.TypeScheduler).HasMaxLength(250);
        });

        modelBuilder.Entity<Sysnotification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("sysnotification");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.NotificationId)
                .HasMaxLength(50)
                .HasColumnName("NotificationID");
            entity.Property(e => e.RoleName).HasMaxLength(255);
            entity.Property(e => e.StatusRead)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.Subject).HasMaxLength(50);
            entity.Property(e => e.TimeStamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp");
            entity.Property(e => e.UserId).HasMaxLength(500);
        });

        modelBuilder.Entity<Tenant>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tenant");

            entity.HasIndex(e => e.PriceId, "FK_tenant_refprice");

            entity.HasIndex(e => e.Price, "Price");

            entity.HasIndex(e => e.WebsiteStatus, "WebsiteStatus");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.AcceptTermRegister).HasColumnType("tinyint(4)");
            entity.Property(e => e.AcceptTerms).HasColumnType("tinyint(4)");
            entity.Property(e => e.ActiveFlag).HasColumnType("int(11)");
            entity.Property(e => e.Address)
                .HasMaxLength(300)
                .HasDefaultValueSql("''");
            entity.Property(e => e.City).HasColumnType("int(11)");
            entity.Property(e => e.ConfirmWebsiteLink).HasMaxLength(500);
            entity.Property(e => e.ConnectionString)
                .HasMaxLength(500)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ContactName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ContactNo)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Country).HasColumnType("int(11)");
            entity.Property(e => e.CreatedBy).HasMaxLength(50);
            entity.Property(e => e.DateCreated)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Handle)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.MosqueId).HasMaxLength(50);
            entity.Property(e => e.MosqueLogo)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.MosqueName)
                .HasMaxLength(255)
                .HasDefaultValueSql("''");
            entity.Property(e => e.PostCode).HasMaxLength(50);
            entity.Property(e => e.Price).HasPrecision(10, 2);
            entity.Property(e => e.PriceId)
                .HasColumnType("int(10) unsigned")
                .HasColumnName("PriceID");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.SiteName)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
            entity.Property(e => e.State).HasColumnType("int(11)");
            entity.Property(e => e.TablePrefix).HasMaxLength(50);
            entity.Property(e => e.UrlPrefix).HasMaxLength(255);
            entity.Property(e => e.WebsiteLink).HasMaxLength(500);
            entity.Property(e => e.WebsiteStatus).HasColumnType("tinyint(4)");

            entity.HasOne(d => d.PriceNavigation).WithMany(p => p.Tenants)
                .HasForeignKey(d => d.PriceId)
                .HasConstraintName("FK_tenant_refprice");
        });

        modelBuilder.Entity<Tenantsubscription>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tenantsubscription");

            entity.HasIndex(e => e.MosqueId, "MosqueID");

            entity.HasIndex(e => e.SubscriptionStatus, "SubscriptionStatus");

            entity.Property(e => e.Id)
                .HasColumnType("int(11) unsigned")
                .HasColumnName("ID");
            entity.Property(e => e.ActiveFlag).HasColumnType("tinyint(4)");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateModified).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .HasDefaultValueSql("''");
            entity.Property(e => e.Dstamp)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("DStamp");
            entity.Property(e => e.Duration).HasMaxLength(50);
            entity.Property(e => e.ModifiedBy).HasMaxLength(50);
            entity.Property(e => e.MosqueId)
                .HasDefaultValueSql("'0'")
                .HasColumnType("int(11) unsigned")
                .HasColumnName("MosqueID");
            entity.Property(e => e.ReminderSubscribeDate).HasColumnType("datetime");
            entity.Property(e => e.RenewalEndDate).HasColumnType("datetime");
            entity.Property(e => e.RenewalStartDate).HasColumnType("datetime");
            entity.Property(e => e.SiteName).HasMaxLength(255);
            entity.Property(e => e.SubscribeEndDate).HasColumnType("datetime");
            entity.Property(e => e.SubscribeStartDate).HasColumnType("datetime");
            entity.Property(e => e.SubscriptionStatus).HasColumnType("tinyint(4)");

            entity.HasOne(d => d.Mosque).WithMany(p => p.Tenantsubscriptions)
                .HasForeignKey(d => d.MosqueId)
                .HasConstraintName("FK_tenantsubscription_tenant");
        });

        modelBuilder.Entity<V1Aliaspartindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_aliaspartindex");

            entity.HasIndex(e => new { e.DocumentId, e.Alias, e.ContentItemId, e.Published, e.Latest }, "IDX_AliasPartIndex_DocumentId");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_AliasPartIndex");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Alias).HasMaxLength(740);
            entity.Property(e => e.ContentItemId).HasMaxLength(26);
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Latest)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Aliaspartindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_AliasPartIndex");
        });

        modelBuilder.Entity<V1Autoroutepartindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_autoroutepartindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_AutoroutePartIndex");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContainedContentItemId).HasMaxLength(26);
            entity.Property(e => e.ContentItemId).HasMaxLength(26);
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Latest).HasColumnType("bit(1)");
            entity.Property(e => e.Path).HasMaxLength(1024);
            entity.Property(e => e.Published).HasColumnType("bit(1)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Autoroutepartindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_AutoroutePartIndex");
        });

        modelBuilder.Entity<V1Containedpartindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_containedpartindex");

            entity.HasIndex(e => new { e.DocumentId, e.ListContentItemId, e.Order }, "IDX_ContainedPartIndex_DocumentId");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_ContainedPartIndex");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.ListContentItemId).HasMaxLength(26);
            entity.Property(e => e.Order).HasColumnType("int(11)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Containedpartindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_ContainedPartIndex");
        });

        modelBuilder.Entity<V1Contentitemindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_contentitemindex");

            entity.HasIndex(e => new { e.DocumentId, e.ContentItemId, e.ContentItemVersionId, e.Published, e.Latest }, "IDX_ContentItemIndex_DocumentId");

            entity.HasIndex(e => new { e.DocumentId, e.Author, e.Published, e.Latest }, "IDX_ContentItemIndex_DocumentId_Author");

            entity.HasIndex(e => new { e.DocumentId, e.ContentType, e.CreatedUtc, e.ModifiedUtc, e.PublishedUtc, e.Published, e.Latest }, "IDX_ContentItemIndex_DocumentId_ContentType");

            entity.HasIndex(e => new { e.DocumentId, e.DisplayText, e.Published, e.Latest }, "IDX_ContentItemIndex_DocumentId_DisplayText");

            entity.HasIndex(e => new { e.DocumentId, e.Owner, e.Published, e.Latest }, "IDX_ContentItemIndex_DocumentId_Owner");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_ContentItemIndex");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContentItemId).HasMaxLength(26);
            entity.Property(e => e.ContentItemVersionId).HasMaxLength(26);
            entity.Property(e => e.CreatedUtc).HasColumnType("datetime");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Latest).HasColumnType("bit(1)");
            entity.Property(e => e.ModifiedUtc).HasColumnType("datetime");
            entity.Property(e => e.Published).HasColumnType("bit(1)");
            entity.Property(e => e.PublishedUtc).HasColumnType("datetime");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Contentitemindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_ContentItemIndex");
        });

        modelBuilder.Entity<V1Deploymentplanindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_deploymentplanindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_DeploymentPlanIndex");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.V1Deploymentplanindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_DeploymentPlanIndex");
        });

        modelBuilder.Entity<V1Document>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_document");

            entity.HasIndex(e => e.Type, "IX_Document_Type");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)");
            entity.Property(e => e.Version).HasColumnType("bigint(20)");
        });

        modelBuilder.Entity<V1Identifier>(entity =>
        {
            entity.HasKey(e => e.Dimension).HasName("PRIMARY");

            entity.ToTable("v1_identifiers");

            entity.Property(e => e.Dimension).HasColumnName("dimension");
            entity.Property(e => e.Nextval)
                .HasColumnType("bigint(20) unsigned")
                .HasColumnName("nextval");
        });

        modelBuilder.Entity<V1Indexingtask>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_indexingtask");

            entity.HasIndex(e => e.ContentItemId, "IDX_IndexingTask_ContentItemId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContentItemId).HasMaxLength(26);
            entity.Property(e => e.CreatedUtc).HasColumnType("datetime");
            entity.Property(e => e.Type).HasColumnType("int(11)");
        });

        modelBuilder.Entity<V1Layermetadataindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_layermetadataindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_LayerMetadataIndex");

            entity.HasIndex(e => new { e.DocumentId, e.Zone }, "IDX_LayerMetadataIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Zone).HasMaxLength(64);

            entity.HasOne(d => d.Document).WithMany(p => p.V1Layermetadataindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_LayerMetadataIndex");
        });

        modelBuilder.Entity<V1Localizedcontentitemindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_localizedcontentitemindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_LocalizedContentItemIndex");

            entity.HasIndex(e => new { e.DocumentId, e.LocalizationSet, e.Culture, e.ContentItemId, e.Published, e.Latest }, "IDX_LocalizationPartIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContentItemId).HasMaxLength(26);
            entity.Property(e => e.Culture).HasMaxLength(16);
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Latest).HasColumnType("bit(1)");
            entity.Property(e => e.LocalizationSet).HasMaxLength(26);
            entity.Property(e => e.Published).HasColumnType("bit(1)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Localizedcontentitemindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_LocalizedContentItemIndex");
        });

        modelBuilder.Entity<V1Taxonomyindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_taxonomyindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_TaxonomyIndex");

            entity.HasIndex(e => new { e.DocumentId, e.TaxonomyContentItemId, e.ContentItemId, e.TermContentItemId, e.Published, e.Latest }, "IDX_TaxonomyIndex_DocumentId");

            entity.HasIndex(e => new { e.DocumentId, e.ContentType, e.ContentPart, e.ContentField, e.Published, e.Latest }, "IDX_TaxonomyIndex_DocumentId_ContentType");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ContentItemId).HasMaxLength(26);
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.Latest)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.Published)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.TaxonomyContentItemId).HasMaxLength(26);
            entity.Property(e => e.TermContentItemId).HasMaxLength(26);

            entity.HasOne(d => d.Document).WithMany(p => p.V1Taxonomyindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_TaxonomyIndex");
        });

        modelBuilder.Entity<V1Userbyclaimindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_userbyclaimindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_UserByClaimIndex");

            entity.HasIndex(e => new { e.DocumentId, e.ClaimType, e.ClaimValue }, "IDX_UserByClaimIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Userbyclaimindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_UserByClaimIndex");
        });

        modelBuilder.Entity<V1Userbylogininfoindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_userbylogininfoindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_UserByLoginInfoIndex");

            entity.HasIndex(e => new { e.DocumentId, e.LoginProvider, e.ProviderKey }, "IDX_UserByLoginInfoIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Userbylogininfoindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_UserByLoginInfoIndex");
        });

        modelBuilder.Entity<V1Userbyrolenameindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_userbyrolenameindex");

            entity.HasIndex(e => e.RoleName, "IDX_UserByRoleNameIndex_RoleName");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.Count).HasColumnType("int(11)");
        });

        modelBuilder.Entity<V1UserbyrolenameindexDocument>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("v1_userbyrolenameindex_document");

            entity.HasIndex(e => new { e.UserByRoleNameIndexId, e.DocumentId }, "IDX_FK_UserByRoleNameIndex_Document");

            entity.HasIndex(e => e.DocumentId, "v1_FK_UserByRoleNameIndex_Document_DocumentId");

            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.UserByRoleNameIndexId).HasColumnType("int(11)");

            entity.HasOne(d => d.Document).WithMany()
                .HasForeignKey(d => d.DocumentId)
                .HasConstraintName("v1_FK_UserByRoleNameIndex_Document_DocumentId");

            entity.HasOne(d => d.UserByRoleNameIndex).WithMany()
                .HasForeignKey(d => d.UserByRoleNameIndexId)
                .HasConstraintName("v1_FK_UserByRoleNameIndex_Document_Id");
        });

        modelBuilder.Entity<V1Userindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_userindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_UserIndex");

            entity.HasIndex(e => new { e.DocumentId, e.UserId, e.NormalizedUserName, e.NormalizedEmail, e.IsEnabled }, "IDX_UserIndex_DocumentId");

            entity.HasIndex(e => new { e.DocumentId, e.IsLockoutEnabled, e.LockoutEndUtc, e.AccessFailedCount }, "IDX_UserIndex_Lockout");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.AccessFailedCount).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.IsEnabled)
                .HasDefaultValueSql("b'1'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.IsLockoutEnabled)
                .HasDefaultValueSql("b'0'")
                .HasColumnType("bit(1)");
            entity.Property(e => e.LockoutEndUtc).HasColumnType("datetime");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Userindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_UserIndex");
        });

        modelBuilder.Entity<V1Workflowblockingactivitiesindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_workflowblockingactivitiesindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_WorkflowBlockingActivitiesIndex");

            entity.HasIndex(e => new { e.DocumentId, e.ActivityId, e.WorkflowTypeId, e.WorkflowId }, "IDX_WFBlockingActivities_DocumentId_ActivityId");

            entity.HasIndex(e => new { e.DocumentId, e.ActivityName, e.WorkflowTypeId, e.WorkflowCorrelationId }, "IDX_WFBlockingActivities_DocumentId_ActivityName");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.ActivityIsStart).HasColumnType("bit(1)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Workflowblockingactivitiesindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_WorkflowBlockingActivitiesIndex");
        });

        modelBuilder.Entity<V1Workflowindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_workflowindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_WorkflowIndex");

            entity.HasIndex(e => new { e.DocumentId, e.WorkflowTypeId, e.WorkflowId, e.WorkflowStatus, e.CreatedUtc }, "IDX_WorkflowIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.CreatedUtc).HasColumnType("datetime");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Workflowindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_WorkflowIndex");
        });

        modelBuilder.Entity<V1Workflowtypeindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_workflowtypeindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_WorkflowTypeIndex");

            entity.HasIndex(e => new { e.DocumentId, e.WorkflowTypeId, e.Name, e.IsEnabled, e.HasStart }, "IDX_WorkflowTypeIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.HasStart).HasColumnType("bit(1)");
            entity.Property(e => e.IsEnabled).HasColumnType("bit(1)");

            entity.HasOne(d => d.Document).WithMany(p => p.V1Workflowtypeindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_WorkflowTypeIndex");
        });

        modelBuilder.Entity<V1Workflowtypestartactivitiesindex>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("v1_workflowtypestartactivitiesindex");

            entity.HasIndex(e => e.DocumentId, "IDX_FK_WorkflowTypeStartActivitiesIndex");

            entity.HasIndex(e => new { e.DocumentId, e.WorkflowTypeId, e.StartActivityId, e.StartActivityName, e.IsEnabled }, "IDX_WorkflowTypeStartActivitiesIndex_DocumentId");

            entity.Property(e => e.Id).HasColumnType("int(11)");
            entity.Property(e => e.DocumentId).HasColumnType("int(11)");
            entity.Property(e => e.IsEnabled).HasColumnType("bit(1)");
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Document).WithMany(p => p.V1Workflowtypestartactivitiesindices)
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("v1_FK_WorkflowTypeStartActivitiesIndex");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
