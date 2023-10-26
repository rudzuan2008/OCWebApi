using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Userbyclaimindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? ClaimType { get; set; }

    public string? ClaimValue { get; set; }

    public virtual V1Document? Document { get; set; }
}
