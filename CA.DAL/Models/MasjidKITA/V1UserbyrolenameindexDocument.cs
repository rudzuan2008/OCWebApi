using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1UserbyrolenameindexDocument
{
    public int UserByRoleNameIndexId { get; set; }

    public int DocumentId { get; set; }

    public virtual V1Document Document { get; set; } = null!;

    public virtual V1Userbyrolenameindex UserByRoleNameIndex { get; set; } = null!;
}
