using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Contactu
{
    public uint Id { get; set; }

    public string? TicketId { get; set; }

    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? PhoneNo { get; set; }

    public string? Inquiry { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? DateModified { get; set; }

    public DateTime? Dstamp { get; set; }

    public sbyte? ActiveFlag { get; set; }
}
