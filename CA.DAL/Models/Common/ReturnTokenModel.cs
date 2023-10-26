using System.IdentityModel.Tokens.Jwt;

namespace CA.DAL.Models.Common
{
    public class ReturnTokenModel
    {
        public string Token { get; set; } = null!;
        public JwtSecurityToken SecurityToken { get; set; } = null!;
    }
}
