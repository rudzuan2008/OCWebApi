using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Indexingtask
{
    public int Id { get; set; }

    public string? ContentItemId { get; set; }

    public DateTime CreatedUtc { get; set; }

    public int? Type { get; set; }
}
