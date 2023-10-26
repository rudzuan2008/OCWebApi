using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Autoroutepartindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? ContentItemId { get; set; }

    public string? ContainedContentItemId { get; set; }

    public string? JsonPath { get; set; }

    public string? Path { get; set; }

    public ulong? Published { get; set; }

    public ulong? Latest { get; set; }

    public virtual V1Document? Document { get; set; }
}
