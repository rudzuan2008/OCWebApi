using System.ComponentModel;

namespace CA.DAL.Models.Common
{
    public class LoginModel
    {
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public bool IsClient { get; set; } = true;
    }
    public class ActivateClientModel
    {
        [DefaultValue(null)]
        public string? UnitNo { get; set; } //RzAsset.Model
        [DefaultValue(null)]
        public int? ClientId { get; set; }

    }
    public class ActivateStaffModel
    {
        [DefaultValue(null)]
        public string? Username { get; set; } //RzAsset.Model
        [DefaultValue(null)]
        public int? StaffId { get; set; }

    }
}
