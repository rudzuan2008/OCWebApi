namespace CA.DAL.Models.Common
{
    public class LoginResponseModel
    {
        public string? Token { get; set; }
        public DateTime? Expiration { get; set; }
        public string? Message { get; set; }
        public string? Code { get; set; }
        public LoginUserModel? User { get; set; }
    }
}
