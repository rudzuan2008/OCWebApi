using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Downloadcharge
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public decimal? Amount { get; set; }

    public string? DocId { get; set; }

    public string? PayStatus { get; set; }

    public string? RefId { get; set; }

    public int? CodeSentStatus { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Dstamp { get; set; }

    public sbyte? ActiveFlag { get; set; }

    public string? Attachment { get; set; }
}
