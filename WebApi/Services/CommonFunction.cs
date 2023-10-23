using CA.DAL;
using CA.DAL.Models;
using CA.DAL.Models.MasjidKITA;
using Serilog;
using System.Runtime.CompilerServices;

namespace MasjidKITA.Services
{
    public class CommonFunction
    {
        private readonly CADbContext _dbcontext;

        public CommonFunction(CADbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public void LogConsole(string message,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string? caller = null)
        {
            // final output
            Console.WriteLine("(" + caller + ") " + message + " PASS at line " + lineNumber);
        }
        public void LogMessage(string message,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string? caller = null)
        {
            Log.Warning("(" + caller + ") " + message + " PASS at line " + lineNumber);
        }
        public void LogError(string message,
        [CallerLineNumber] int lineNumber = 0,
        [CallerMemberName] string? caller = null)
        {
            Log.Error("(" + caller + ") " + message + " at line " + lineNumber);
        }
    }
}
