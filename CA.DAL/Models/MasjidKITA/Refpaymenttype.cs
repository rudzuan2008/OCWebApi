using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Refpaymenttype
{
    public uint Id { get; set; }

    public sbyte Type { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public sbyte? ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? Dstamp { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
