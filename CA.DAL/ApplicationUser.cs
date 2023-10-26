using Microsoft.AspNetCore.Identity;

namespace CA.DAL
{
    public class ApplicationUser : IdentityUser
    {
        public string? NetworkId { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? ModifiedDtm { get; set; }
        public string? Name { get; set; }
        public string? Status { get; set; }
        public string? OfficePhone { get; set; }
        public DateTime? LastSeenDtm { get; set; }
        public string CreatedBy { get; set; } = null!;
        public DateTime CreatedDtm { get; set; }
        public decimal RecId { get; set; }
        public string? Supervisor { get; set; } 
        public bool HasBillingEngineId { get; set; } = false;
        public string? UnitOffice { get; set; }
        public string? Department { get; set; }
    }
}
