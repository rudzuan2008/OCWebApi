using System;
using System.Collections.Generic;

namespace CA.DAL.Models.MasjidKITA;

public partial class Scheduler
{
    public int Id { get; set; }

    public string? TenantId { get; set; }

    public string? TypeScheduler { get; set; }

    public string? Handle { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public int? DurationType { get; set; }

    public string? DayTrigger { get; set; }

    public int? Frequency { get; set; }

    public string? CronScheduler { get; set; }
}
