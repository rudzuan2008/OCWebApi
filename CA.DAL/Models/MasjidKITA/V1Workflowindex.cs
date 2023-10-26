using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class V1Workflowindex
{
    public int Id { get; set; }

    public int? DocumentId { get; set; }

    public string? WorkflowTypeId { get; set; }

    public string? WorkflowId { get; set; }

    public string? WorkflowStatus { get; set; }

    public DateTime? CreatedUtc { get; set; }

    public virtual V1Document? Document { get; set; }
}
