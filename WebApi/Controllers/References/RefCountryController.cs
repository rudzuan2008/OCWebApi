using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TE.DAL;
using CA.DAL;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.DynamicLinq;

namespace MasjidKITA.Controllers.References
{
    [Route("api/[controller]")]
    [ApiController]
    public class RefCountryController : IBaseController
    {
        private readonly string _module = "AuthenticationController";
        private readonly ILogger<RefCountryController> _logger;
        public RefCountryController(IWebHostEnvironment environment, IConfiguration configuration, CADbContext dbcontext, TEDbContext dbtenantcontext, ILogger<RefCountryController> logger) : base(environment, configuration, dbcontext, dbtenantcontext)
        {
            _logger = logger;
            _cf.LogConsole($"{_module} start...");
        }
        [HttpGet]
        public async Task<IActionResult> Get(int? id)
        {
            var msg = "Country Data";
            try
            {
                var refCountry = await _dbcontext.Refcountries.Where(m=>m.Id == id).FirstOrDefaultAsync();
                return Ok(refCountry, msg);
            }
            catch (Exception ex)
            {
                msg = string.Format("{0} Error : {1}", ex.Message, ex.InnerException); _cf.LogError(msg);
            }
            return Error("ERR", msg);
        }
        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> All(int? skip = 0, int? take = 5, string? ord = "CountryName", bool? desc = false)
        {
            var msg = "Country Data";
            try
            {
                //_cf.LogConsole("Start");
                _logger.LogError("Start here");
                var refCountry = await _dbcontext.Refcountries
                    .Include(s=>s.Refstates).ThenInclude(c=>c.Refcities)
                    .ToListAsync();
                if (refCountry != null)
                {
                    return Ok(refCountry, msg);
                }
                else return NoContent("No Record Found");
            }
            catch (Exception ex)
            {
                msg = string.Format("{0} Error : {1}", ex.Message, ex.InnerException); _cf.LogError(msg);
            }
            return Error("ERR", msg);
        }


    }
}
