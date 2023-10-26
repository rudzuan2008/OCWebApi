using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Contentitemindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? ContentItemId { get; set; }

    public string? ContentItemVersionId { get; set; }

    public ulong? Latest { get; set; }

    public ulong? Published { get; set; }

    public string? ContentType { get; set; }

    public DateTime? ModifiedUtc { get; set; }

    public DateTime? PublishedUtc { get; set; }

    public DateTime? CreatedUtc { get; set; }

    public string? Owner { get; set; }

    public string? Author { get; set; }

    public string? DisplayText { get; set; }

    public virtual V1Document? Document { get; set; }
}
