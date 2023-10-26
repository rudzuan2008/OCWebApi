using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Workflowblockingactivitiesindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? ActivityId { get; set; }

    public string? ActivityName { get; set; }

    public ulong? ActivityIsStart { get; set; }

    public string? WorkflowTypeId { get; set; }

    public string? WorkflowId { get; set; }

    public string? WorkflowCorrelationId { get; set; }

    public virtual V1Document? Document { get; set; }
}
