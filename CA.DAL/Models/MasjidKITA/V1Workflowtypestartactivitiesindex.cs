﻿using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Workflowtypestartactivitiesindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? WorkflowTypeId { get; set; }

    public string? Name { get; set; }

    public ulong? IsEnabled { get; set; }

    public string? StartActivityId { get; set; }

    public string? StartActivityName { get; set; }

    public virtual V1Document? Document { get; set; }
}
