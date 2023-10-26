using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Refstate
{
    public int Id { get; set; }

    public uint CountryId { get; set; }

    public string? StateName { get; set; }

    public string? StateCode { get; set; }

    public DateTime? Dstamp { get; set; }

    public virtual Refcountry Country { get; set; } = null!;

    public virtual ICollection<Refcity> Refcities { get; set; } = new List<Refcity>();
}
