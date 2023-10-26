using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Audit
{
    public uint Id { get; set; }

    public int? AuditType { get; set; }

    public string? UserId { get; set; }

    public string? Method { get; set; }

    public string? Message { get; set; }

    public DateTime? DateCreated { get; set; }

    public sbyte ActiveFlag { get; set; }

    public DateTime? Dstamp { get; set; }
}
