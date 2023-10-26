using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Aliaspartindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? Alias { get; set; }

    public string? ContentItemId { get; set; }

    public ulong? Latest { get; set; }

    public ulong? Published { get; set; }

    public virtual V1Document? Document { get; set; }
}
