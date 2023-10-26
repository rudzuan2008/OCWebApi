using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Userindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? NormalizedUserName { get; set; }

    public string? NormalizedEmail { get; set; }

    public ulong IsEnabled { get; set; }

    public ulong IsLockoutEnabled { get; set; }

    public DateTime? LockoutEndUtc { get; set; }

    public int AccessFailedCount { get; set; }

    public string? UserId { get; set; }

    public virtual V1Document? Document { get; set; }
}
