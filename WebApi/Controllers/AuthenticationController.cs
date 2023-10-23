using CA.DAL;
using CA.DAL.Models.Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TE.DAL;

namespace MasjidKITA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : IBaseController
    {
        private readonly string _module = "AuthenticationController";
        public AuthenticationController(IWebHostEnvironment environment, IConfiguration configuration, CADbContext dbcontext, TEDbContext dbtenantcontext) : base(environment, configuration, dbcontext, dbtenantcontext)
        {
            _cf.LogConsole($"{_module} start...");
        }
        private ReturnTokenModel? BuildJWTToken()
        {
            
            var secret = _configuration["JWT:Secret"];
            if (secret != null)
            {
                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
                var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:ExpiresMinutes"]));
                var securityToken = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: jwtValidity,
                    //claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
                return new ReturnTokenModel { Token = token, SecurityToken = securityToken };
            }
            else return null;

            //var secret = _configuration["JWT:Secret"];
            //if (secret != null)
            //{
            //    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //    var issuer = _configuration["JWT:ValidIssuer"];
            //    var audience = _configuration["JWT:ValidAudience"];
            //    var jwtValidity = DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["JWT:ExpiresMinutes"]));

            //    var securityToken = new JwtSecurityToken(issuer,
            //      audience,
            //      expires: jwtValidity,
            //      signingCredentials: creds);

            //    var token = new JwtSecurityTokenHandler().WriteToken(securityToken);
            //    //return new JwtSecurityTokenHandler().WriteToken(token);
            //    return new ReturnTokenModel { Token = token, SecurityToken = securityToken };
            //}
            //else return null;
        }
        private async Task<LoginUserModel?> GetUser(LoginModel login)
        {
            var refCountry = await _dbcontext.Refcountries.FirstOrDefaultAsync();
            var data = new LoginUserModel();
            data.RefId = 1;
            data.Username = "rudzuan";
            data.Password = "abc123";
            data.Salt = refCountry.CountryName;

            return data;

            //var rzUser = await _dbcontext.RzUsers.Where(m => m.Username == login.Username).FirstOrDefaultAsync();
            //if (rzUser != null)
            //{
            //    rzUser.LastLogin = DateTime.Now;
            //    _dbcontext.Update(rzUser);
            //    _dbcontext.SaveChanges();

            //    data.RefId = rzUser.RefId;
            //    data.Username = rzUser.Username;
            //    data.Password = rzUser.Password;
            //    data.RefId = rzUser.RefId;
            //    data.Name = rzUser.Fullname;
            //    data.Email = rzUser.Email;
            //    data.IsClient = rzUser.IsClient;
            //    data.Salt = rzUser.Salt;
            //    data.ListRoles = new List<LoginRole>();
            //    if (data.IsClient != null && !data.IsClient.Value)
            //    {
            //        var roleId = await _dbcontext.RzStaffs.Where(m => m.StaffId == data.RefId).Select(s => s.RoleId).FirstOrDefaultAsync();
            //        if (roleId > 0)
            //        {
            //            var rzRole = await _dbcontext.RzRoles.Where(m => m.RoleId == roleId).FirstOrDefaultAsync();
            //            if (rzRole != null)
            //            {
            //                data.Role = new LoginRole
            //                {
            //                    RecId = rzRole.RoleId,
            //                    Name = rzRole.RoleName,
            //                    Level = rzRole.RoleLevel,
            //                    IsGuardHouse = rzRole.IsGuardHouse,
            //                    IsGuardWatch = rzRole.IsGuardWatch,
            //                    IsEnabled = rzRole.RoleEnabled
            //                };
            //                data.ListRoles.Add(data.Role);
            //            }
            //        }

            //    }
            //    return data;
            //}
            //else return null;
        }
        private async Task<LoginResultModel> Authenticate(LoginModel login)
        {
            bool validUser = false;
            var specialKey = _configuration.GetSection("License:LicenseKey").ToString();
            if (login.Username == specialKey) validUser = true;
            var loginUser = await GetUser(login);

            return new LoginResultModel { IsValid = true, Msg = "Ok! User successfully login", User = loginUser };
            //if (loginUser != null)
            //{
            //    var salt = loginUser.Salt;
            //    if (salt != null && loginUser.Password != null && CheckPasswd(salt, login.Password, loginUser.Password))
            //    {
            //        return new LoginResultModel { IsValid = true, Msg = "Ok! User successfully login", User = loginUser };
            //    }
            //    else return new LoginResultModel { IsValid = true, Msg = "Please update your login cridential", User = loginUser };
            //}
            //else return new LoginResultModel { IsValid = validUser, Msg = "Sorry! User not found" };
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (login == null) return Unauthorized();
            //string tokenString = string.Empty;
            var validUser = await Authenticate(login);
            if (validUser.IsValid)
            {
                var tokenObj = BuildJWTToken();
                if (tokenObj != null)
                {

                    //return Ok(new { Token = tokenString });
                    return Ok(new LoginResponseModel
                    {
                        Token = tokenObj.Token,
                        Expiration = tokenObj.SecurityToken.ValidTo.ToLocalTime(),
                        Message = validUser?.Msg,
                        Code = validUser?.User?.Salt,
                        User = validUser?.User //TODO only for debug
                    }, "Login successfully.");
                }
                else return NoContent("Login failed. Token generation fail.");
            }
            else return Unauthorized();
        }
    }
}
