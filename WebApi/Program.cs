using CA.DAL;
using CA.DAL.Models.MasjidKITA;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Configuration;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TE.DAL;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins"; 
Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File("../logs/webapi-.log",
                          rollingInterval: RollingInterval.Day,
                          outputTemplate: "{Timestamp:dd-MMM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                          restrictedToMinimumLevel: LogEventLevel.Warning)
            .WriteTo.File("../logs/info/webapi-.log",
                          rollingInterval: RollingInterval.Hour,
                          buffered: true,
                          outputTemplate: "{Timestamp:dd-MMM-yyyy HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}",
                          restrictedToMinimumLevel: LogEventLevel.Information)
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Error)
            .Enrich.FromLogContext()
            .CreateLogger();
builder.Logging.AddSerilog(Log.Logger);
// Add services to the container.
var connectionStr = builder.Configuration.GetConnectionString("Default");
var connectionTenantStr = builder.Configuration.GetConnectionString("TenantDb");
// Replace with your connection string.
//var connectionStr = "server=localhost;user=root;password=Password1;database=masjidkita";

// Replace with your server version and type.
// Use 'MariaDbServerVersion' for MariaDB.
// Alternatively, use 'ServerVersion.AutoDetect(connectionString)'.
// For common usages, see pull request #1233.
//var serverVersion = new MySqlServerVersion(new Version(8, 0, 34));
var serverVersion = ServerVersion.AutoDetect(connectionStr);
var serverTenantVersion = ServerVersion.AutoDetect(connectionStr);

//builder.Services.AddEntityFrameworkMySql().AddDbContext<CADbContext>(options =>
//{
//    if (connectionStr != null) options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
//});
// Replace 'YourDbContext' with the name of your own DbContext derived class.
builder.Services.AddDbContext<CADbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionStr, serverVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
builder.Services.AddDbContext<TEDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionTenantStr, serverTenantVersion)
        // The following three options help with debugging, but should
        // be changed or removed for production.
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
    builder =>
    {
        builder.WithOrigins("https://localhost:7227")
        .SetIsOriginAllowed(_ => true)
        .AllowCredentials().AllowAnyHeader().AllowAnyMethod();
        //.SetIsOriginAllowedToAllowWildcardSubdomains();
    });
    //builder => builder.AllowAnyMethod()
    //                  .AllowAnyHeader()
    //                  .SetIsOriginAllowed(_ => true)
    //                  //.AllowAnyOrigin().
    //                  .AllowCredentials()
    //);
});
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    //Events added as it is needed from Dev Extreme Reporting
    options.Events = new JwtBearerEvents();
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer =  builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
        ClockSkew = TimeSpan.Zero
    };
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "MasjidKITA Web API",
        Description = "MasjidKITA Web API, build: " + Assembly.GetEntryAssembly()?.GetName().Version
    });
    // To Enable authorization using Swagger (JWT)    
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

//For Identity
//builder.Services.AddDbContext<CADbContext>(options =>
//{
//    options.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr));
//    //options.UseOracle(DalEncryption.DecryptString(builder.Configuration, builder.Configuration.GetConnectionString("OracleAuth")));
//#if (DEBUG)
//    options.LogTo(Console.WriteLine);
//#endif
//    options.LogTo(Log.Logger.Information);
//});
//builder.Services.AddDbContext<TEDbContext>(options =>
//{
//    options.UseMySql(builder.Configuration.GetConnectionString("TenantDB"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("TenantDB")));
//    //options.UseOracle(DalEncryption.DecryptString(builder.Configuration, builder.Configuration.GetConnectionString("OracleBEAuth")));
//#if (DEBUG)
//    options.LogTo(Console.WriteLine);
//#endif
//    options.LogTo(Log.Logger.Information);
//});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<CADbContext>()
    .AddDefaultTokenProviders();

//To preserved return array in web api json return
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.PropertyNamingPolicy = null; // prevent camel case
    });
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors();
app.UseAuthentication();
app.UseAuthorization();
//app.MapControllers();
app.UseEndpoints(endpoints =>
{
    //endpoints.MapControllers().RequireAuthorization();
    endpoints.MapControllers();
    endpoints.MapControllerRoute("default", "Web api");
    //endpoints.MapMetrics("/internal/metrics").AllowAnonymous().RequireHost("localhost", "web-api");
});
app.Run();
