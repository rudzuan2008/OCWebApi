using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Tenant
{
    public uint Id { get; set; }

    public string? MosqueId { get; set; }

    public string Handle { get; set; } = null!;

    public string SiteName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string RecipeName { get; set; } = null!;

    public sbyte AcceptTerms { get; set; }

    public int? ActiveFlag { get; set; }

    public string? ConnectionString { get; set; }

    public string? TablePrefix { get; set; }

    public string? ConfirmWebsiteLink { get; set; }

    public string? WebsiteLink { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? Dstamp { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public uint? PriceId { get; set; }

    public sbyte? WebsiteStatus { get; set; }

    public string? ContactName { get; set; }

    public string? ContactNo { get; set; }

    public string? MosqueLogo { get; set; }

    public string? MosqueName { get; set; }

    public decimal? Price { get; set; }

    public string? Address { get; set; }

    public int? City { get; set; }

    public int? State { get; set; }

    public int? Country { get; set; }

    public string? PostCode { get; set; }

    public sbyte? AcceptTermRegister { get; set; }

    public string? UrlPrefix { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual Refprice? PriceNavigation { get; set; }

    public virtual ICollection<Tenantsubscription> Tenantsubscriptions { get; set; } = new List<Tenantsubscription>();
}
