using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Refgroupone
{
    public uint Id { get; set; }

    public sbyte? Type { get; set; }

    public string Name { get; set; } = null!;

    public uint CategoryId { get; set; }

    public string Category { get; set; } = null!;

    public byte ActiveFlag { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? Dstamp { get; set; }
}
