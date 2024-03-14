
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Drawing.Text;
using ValhallaVault.Data.Models;

namespace ValhallaVault.Data.Middleware
{
    public class CustomLogger : IMiddleware
    {
        private readonly ProgramDbContext _dbContext;

        public CustomLogger( ProgramDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {

            await AddToContextAsync(context.Request.Path, context.Request.Method, context.Response.StatusCode);

            await next(context);
        }

        public async Task AddToContextAsync( string method, string path, int statusCode)
        {
            RequestLogs requestLogs = new RequestLogs()
            {
                Method = method,
                Path = path,
                StatusCode = statusCode,
                LogTime = DateTime.Now

            };

            await _dbContext.RequestLogs.AddAsync(requestLogs);

            await _dbContext.SaveChangesAsync();
        }
    }
}
