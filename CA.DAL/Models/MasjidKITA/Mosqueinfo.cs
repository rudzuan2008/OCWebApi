using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Mosqueinfo
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public string? Address { get; set; }

    public int? City { get; set; }

    public int? State { get; set; }

    public int? Country { get; set; }

    public int? Postcode { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? Dstamp { get; set; }

    public sbyte? ActiveFlag { get; set; }

    public string? Logo { get; set; }

    public string? UserName { get; set; }

    public string? UserId { get; set; }

    public int? MosqueId { get; set; }
}
