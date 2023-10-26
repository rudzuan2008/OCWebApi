using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Payment
{
    public uint Id { get; set; }

    public uint FkPriceId { get; set; }

    public uint? FkPaymentId { get; set; }

    public sbyte PaymentStatus { get; set; }

    public sbyte? SubscriptionStatus { get; set; }

    public uint? TenantId { get; set; }

    public string InvoiceNo { get; set; } = null!;

    public string? OnlinePaymentId { get; set; }

    public string MosqueId { get; set; } = null!;

    public string? MosqueName { get; set; }

    public string? MosqueAddress { get; set; }

    public string? Email { get; set; }

    public decimal PaymentAmountRm { get; set; }

    public string? BankName { get; set; }

    public string PaymentMethods { get; set; } = null!;

    public string Attachment { get; set; } = null!;

    public DateTime? SubscribeStartDate { get; set; }

    public DateTime? SubscribeEndDate { get; set; }

    public sbyte? ActiveFlag { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime DateCreated { get; set; }

    public DateTime DateModified { get; set; }

    public string ModifiedBy { get; set; } = null!;

    public DateTime? Dstamp { get; set; }

    public sbyte? IsRenewal { get; set; }

    public virtual Refpaymenttype? FkPayment { get; set; }

    public virtual Refprice FkPrice { get; set; } = null!;

    public virtual Tenant? Tenant { get; set; }
}
