using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Identifier
{
    public string Dimension { get; set; } = null!;

    public ulong? Nextval { get; set; }
}
