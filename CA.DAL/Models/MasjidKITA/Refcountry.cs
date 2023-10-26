using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Refcountry
{
    public uint Id { get; set; }

    public string? CountryName { get; set; }

    public string? CountryCode { get; set; }

    public DateTime? Dstamp { get; set; }

    public virtual ICollection<Refstate> Refstates { get; set; } = new List<Refstate>();
}
