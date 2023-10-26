using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Refcity
{
    public uint Id { get; set; }

    public int? StateId { get; set; }

    public string? CityName { get; set; }

    public DateTime? Dstamp { get; set; }

    public virtual Refstate? State { get; set; }
}
