using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Taxonomyindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? TaxonomyContentItemId { get; set; }

    public string? ContentItemId { get; set; }

    public string? ContentType { get; set; }

    public string? ContentPart { get; set; }

    public string? ContentField { get; set; }

    public string? TermContentItemId { get; set; }

    public ulong? Published { get; set; }

    public ulong? Latest { get; set; }

    public virtual V1Document? Document { get; set; }
}
