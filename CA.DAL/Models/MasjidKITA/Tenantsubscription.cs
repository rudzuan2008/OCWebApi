using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Tenantsubscription
{
    public uint Id { get; set; }

    public uint? MosqueId { get; set; }

    public sbyte? SubscriptionStatus { get; set; }

    public string? SiteName { get; set; }

    public string? Duration { get; set; }

    public DateTime? SubscribeStartDate { get; set; }

    public DateTime? SubscribeEndDate { get; set; }

    public DateTime? ReminderSubscribeDate { get; set; }

    public string Description { get; set; } = null!;

    public sbyte? ActiveFlag { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? Dstamp { get; set; }

    public DateTime? RenewalStartDate { get; set; }

    public DateTime? RenewalEndDate { get; set; }

    public virtual Tenant? Mosque { get; set; }
}
