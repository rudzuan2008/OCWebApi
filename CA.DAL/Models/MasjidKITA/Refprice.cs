using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Refprice
{
    public uint Id { get; set; }

    public string? PackageName { get; set; }

    public sbyte? PriceFlag { get; set; }

    public decimal Price { get; set; }

    public decimal? DiscountPrice { get; set; }

    public string? Duration { get; set; }

    public int? TotalMember { get; set; }

    public string? Description { get; set; }

    public string? Description1 { get; set; }

    public string? Description2 { get; set; }

    public string? Description3 { get; set; }

    public string? ImageName { get; set; }

    public string? ImagePath { get; set; }

    public string? ContentItemId { get; set; }

    public string? Pautan { get; set; }

    public sbyte? ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Dstamp { get; set; }

    public sbyte? CustomFlag { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

    public virtual ICollection<Tenant> Tenants { get; set; } = new List<Tenant>();
}
