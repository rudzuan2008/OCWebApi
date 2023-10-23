using MasjidKITA.Constants;
using CA.DAL.Models;
//using helpdeskapi.Models.Common;
//using helpdeskapi.Models.Utility;
using MasjidKITA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using System.Linq.Expressions;
using CA.DAL;
using CA.DAL.Models.Common;
using CA.DAL.Models.MasjidKITA;
using TE.DAL.Models.Tenant;
using TE.DAL;

namespace MasjidKITA.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class IBaseController : ControllerBase
    {
        protected readonly CommonFunction _cf;
        protected readonly CADbContext _dbcontext;
        protected readonly TEDbContext _dbTenantContext;
        protected readonly IWebHostEnvironment _environment;
        protected readonly IConfiguration _configuration;
        protected readonly string? _apiBaseUrl;
        public IBaseController(IWebHostEnvironment environment, IConfiguration configuration, CADbContext dbcontext, TEDbContext dbtenantcontext)
        {
            _dbcontext = dbcontext;
            _dbTenantContext = dbtenantcontext;
            _environment = environment;
            _configuration = configuration;
            _cf = new CommonFunction(dbcontext);
            _apiBaseUrl = _configuration.GetValue<string>("MasjidKITABaseUrl");
        }
        protected bool IsValidString(string word)
        {
            bool checkValid = true;
            if (String.IsNullOrEmpty(word)) checkValid = false;
            if (word == "string") checkValid = false;
            if (word == "") checkValid = false;

            return checkValid;
        }
        protected bool IsValidDate(DateTime? check)
        {
            if (check == null) return false;
            if (check.Value.ToString("dd-MM-yyyy") == "01-01-1900") return false;
            if (check.Value.ToString("dd-MM-yyyy") == "00-00-0000") return false;
            return true;
        }
        protected PaginationInfo GetPaginationInfo(int count, int? skip, int? take)
        {
            var pageInfo = new PaginationInfo();
            decimal tp = (decimal)count / (decimal)take!.Value;
            int totalPage = (int)Math.Ceiling(tp);
            int page = (skip!.Value / take!.Value) + 1;

            pageInfo.TotalPages = totalPage;
            pageInfo.TotalRecords = count;
            pageInfo.RecordPerPage = take!.Value;
            pageInfo.CurrentPageNo = page;

            return pageInfo;
        }
        protected string RandCode(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
        protected string? GetShortcode(string longName)
        {
            string? shortcode = null;
            var aryName = longName.Split(" ");
            if (aryName.Length > 0)
            {
                for(var i=0; i<aryName.Length; i++)
                {
                    shortcode += aryName[i].Substring(0, 1);
                }
            }
            else
            {
                shortcode = longName.Substring(0, 1);
            }
            return shortcode;
        }
        //protected static IQueryable<TEntity> OrderBy<TEntity>(this IQueryable<TEntity> source, string orderByProperty,
        //                  bool desc)
        //{
        //    string command = desc ? "OrderByDescending" : "OrderBy";
        //    var type = typeof(TEntity);
        //    var property = type.GetProperty(orderByProperty);
        //    var parameter = Expression.Parameter(type, "p");
        //    var propertyAccess = Expression.MakeMemberAccess(parameter, property);
        //    var orderByExpression = Expression.Lambda(propertyAccess, parameter);
        //    var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
        //                                  source.Expression, Expression.Quote(orderByExpression));
        //    return source.Provider.CreateQuery<TEntity>(resultExpression);
        //}
        protected OkObjectResult Ok<T>(T data, string returnMessage = "", List<string>? returnParameter = null)
        {
            return base.Ok(new ReturnViewModel
            {
                DateTime = DateTime.Now,
                ReturnCode = (int)HttpStatus.Success,
                Status = "OK",
                Data = data,
                ReturnMessage = returnMessage,
                ReturnParameter = returnParameter
            });
        }
        //protected async Task<StoreTempDownloadFileModel> StoreTemporaryDownloadFile(byte[]? fileData, string fileName, string fileExtension, string contentType)
        //{
        //    var retData = new StoreTempDownloadFileModel();
        //    try
        //    {
        //        var saveData = new TmpFileDownloadModel();
        //        saveData.Guid = Guid.NewGuid().ToString();
        //        saveData.FileData = Convert.ToBase64String(fileData); //Encoding.UTF8.GetString(fileData);
        //        saveData.FileName = fileName;
        //        saveData.FileExt = fileExtension;
        //        saveData.ContentType = contentType;
        //        saveData.CreatedDtm = DateTime.Now;
        //        _iwkContext.Add(saveData);
        //        await _iwkContext.SaveChangesAsync(false);

        //        retData.FileGuid = saveData.Guid;
        //        retData.ContentType = saveData.ContentType;
        //        retData.FullFileName = saveData.FileName + "." + saveData.FileExt;
        //        return retData;
        //    }
        //    catch (Exception ex)
        //    {
        //        retData.FileGuid = $"Failed save file - Error:{ex.Message}";
        //        return retData;
        //    }
        //}
        protected async Task<string?> GetUploadUrl(int? companyId = 2)
        {
            var uploadFolder = _configuration.GetValue<string>("UploadFolder");
            var uploadUrl = $"{_apiBaseUrl}{uploadFolder}";
            //var config = await _dbcontext.RzConfigs.Where(m => m.CompanyId == companyId).FirstOrDefaultAsync();
            //if (config != null && config.UploadUrl != uploadUrl)
            //{
            //    config.UploadUrl = uploadUrl;
            //    await _dbcontext.SaveChangesAsync();
            //}
            return uploadUrl;
        }
        protected async Task<string?> GetUploadDirectory(int? companyId = 2)
        {
            var uploadFolder = _configuration.GetValue<string>("UploadFolder");
            var uploadDir = Path.Combine(_environment.ContentRootPath, uploadFolder);
            //var config = await _dbcontext.RzConfigs.Where(m => m.CompanyId == companyId).FirstOrDefaultAsync();
            //if (config != null && config.UploadDir != uploadDir)
            //{
            //    config.UploadDir = uploadDir;
            //    await _dbcontext.SaveChangesAsync();
            //}
            return uploadDir;
        }
        protected async Task<string> GetFullpath(string filename, string refType, string? filekey, int? companyId = 2)
        {
            //var company = await _dbcontext.RzCompanies.Where(m => m.CompanyId == companyId).FirstOrDefaultAsync();
            if (filekey == null) filekey = RandCode(16);
            var filePath = await GetUploadDirectory(companyId);
            var dir = filePath + "/" + refType.ToUpper();
            if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

            return dir + "/" + filekey + "_" + filename;
        }
        /// <summary>
        /// OK data - 200
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="data">Data object return to caller</param>
        /// <param name="paginationInfo">Pagination Info</param>
        /// <param name="returnMessage">Message to caller</param>
        /// <param name="returnParameter">Parameter for returnMessage</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.OkObjectResult for the response.</returns>
        protected OkObjectResult Ok<T>(T data, PaginationInfo paginationInfo, string returnMessage = "", List<string>? returnParameter = null)
        {
            return base.Ok(new ReturnViewModel
            {
                DateTime = DateTime.Now,
                ReturnCode = (int)HttpStatus.Success,
                Status = "OK",
                Data = data,
                PaginationInfo = paginationInfo,
                ReturnMessage = returnMessage,
                ReturnParameter = returnParameter
            });
        }

        /// <summary>
        /// Failed - Internal Server Error - 500
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="data">Data object return to caller</param>
        /// <param name="returnMessage">Message to caller</param>
        /// <param name="returnParameter">Parameter for returnMessage</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.OkObjectResult for the response.</returns>
        protected BadRequestObjectResult Error<T>(T data, string returnMessage = "", List<string>? returnParameter = null)
        {
            return base.BadRequest(new ReturnViewModel
            {
                DateTime = DateTime.Now,
                ReturnCode = (int)HttpStatus.Error,
                Status = "Error",
                Data = data,
                ReturnMessage = returnMessage,
                ReturnParameter = returnParameter
            });
        }

        /// <summary>
        /// Unauthorized - 401
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="data">Data object return to caller</param>
        /// <param name="returnMessage">Message to caller</param>
        /// <param name="returnParameter">Parameter for returnMessage</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.OkObjectResult for the response.</returns>
        protected UnauthorizedObjectResult Unauthorized<T>(T data, string returnMessage = "", List<string>? returnParameter = null)
        {
            return base.Unauthorized(new ReturnViewModel
            {
                DateTime = DateTime.Now,
                ReturnCode = (int)HttpStatus.NoRequestAuthority,
                Status = "Unauthorized",
                Data = data,
                ReturnMessage = returnMessage,
                ReturnParameter = returnParameter
            });
        }

        /// <summary>
        /// Not Found - 404.
        /// Don't use for record not found.
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="data">Data object return to caller</param>
        /// <param name="returnMessage">Message to caller</param>
        /// <param name="returnParameter">Parameter for returnMessage</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.NotFoundObjectResult for the response.</returns>
        protected NotFoundObjectResult NotFound<T>(T data, string returnMessage = "", List<string>? returnParameter = null)
        {
            return base.NotFound(new ReturnViewModel
            {
                DateTime = DateTime.Now,
                ReturnCode = (int)HttpStatus.NotFound,
                Status = "NotFound",
                Data = data,
                ReturnMessage = returnMessage,
                ReturnParameter = returnParameter
            });
        }

        /// <summary>
        /// Return file with custom header message for filename
        /// </summary>
        /// <param name="fileContents"></param>
        /// <param name="contentType"></param>
        /// <param name="fileDownloadName"></param>
        /// <returns></returns>
        protected FileContentResult File(byte[] fileContents, string contentType, string fileDownloadName)
        {
            Response.Headers.Add("return-message", $"filename={fileDownloadName}");
            Response.Headers.Add("return-server", Environment.MachineName);
            return base.File(fileContents, contentType, fileDownloadName);
        }

        /// <summary>
        /// No Content / Data Not Found - 204
        /// </summary>
        /// <param name="returnMessage">Message to caller at Header</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.NoContentResult for the response.</returns>
        protected NoContentResult NoContent(string returnMessage = "")
        {
            Response.Headers.Add("return-message", returnMessage);
            Response.Headers.Add("return-server", Environment.MachineName);
            return base.NoContent();
        }

        /// <summary>
        /// Bad Request - 400
        /// </summary>
        /// <typeparam name="T">object</typeparam>
        /// <param name="data">Data object return to caller</param>
        /// <param name="returnMessage">Message to caller</param>
        /// <param name="returnParameter">Parameter for returnMessage</param>
        /// <returns>The created Microsoft.AspNetCore.Mvc.OkObjectResult for the response.</returns>
        protected BadRequestObjectResult BadRequest<T>(T data, string returnMessage = "", List<string>? returnParameter = null)
        {
            return base.BadRequest(new ReturnViewModel
            {
                DateTime = DateTime.Now,
                ReturnCode = (int)HttpStatus.BadRequest,
                Status = "BadRequest",
                Data = data,
                ReturnMessage = returnMessage,
                ReturnParameter = returnParameter
            });
        }

    }
}
