namespace CA.DAL.Models.Common
{
    public class LoginResultModel
    {
        public bool IsValid { get; set; } = true;
        public string? Msg { get; set; }
        public LoginUserModel? User { get; set; }
    }
}
