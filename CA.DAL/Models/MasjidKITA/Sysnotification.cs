using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Sysnotification
{
    public int Id { get; set; }

    public string? NotificationId { get; set; }

    public string? Subject { get; set; }

    public string? Description { get; set; }

    public string? UserId { get; set; }

    public DateTime? DateCreated { get; set; }

    public ulong? StatusRead { get; set; }

    public ulong? ActiveFlag { get; set; }

    public DateTime? TimeStamp { get; set; }

    public string? RoleName { get; set; }
}
