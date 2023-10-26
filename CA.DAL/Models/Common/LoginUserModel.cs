namespace CA.DAL.Models.Common
{
    public class LoginUserModel
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Salt { get; set; }

        public int? RefId { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public bool? IsClient { get; set; }
        public DateTime? LastLogin { get; set; }
        //public LoginRole Role { get; set; } = null!;
        //public List<LoginRole> ListRoles { get; set; } = null!;
    }
    public class LoginRole
    {
        public decimal RecId { get; set; }
        public string Name { get; set; } = null!;
        public int? Level { get; set; }
        //public bool? IsGuardHouse { get; set; } = false;
        //public bool? IsGuardWatch { get; set; } = false;
        //public bool? IsEnabled { get; set; } = true;
    }
}
