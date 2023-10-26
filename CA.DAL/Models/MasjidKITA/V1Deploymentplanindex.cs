using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Deploymentplanindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? Name { get; set; }

    public virtual V1Document? Document { get; set; }
}
