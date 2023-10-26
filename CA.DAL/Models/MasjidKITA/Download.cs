using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Download
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string Description { get; set; } = null!;

    public int? TotalDownload { get; set; }

    public string? Version { get; set; }

    public string? Status { get; set; }

    public sbyte Chargeable { get; set; }

    public string? DownloadCode { get; set; }

    public sbyte ActiveFlag { get; set; }

    public string? CreatedBy { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? Dstamp { get; set; }

    public decimal? Amount { get; set; }

    public string? Attachment { get; set; }
}
