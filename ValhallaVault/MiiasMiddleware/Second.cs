using System.Net;

namespace ValhallaVault.MiiasMiddleware
{
    public class Second
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Second> _logger;

        /*Om jag har fattat detta rätt så funkar även denna. När jag skriver jag följande:
        //https://localhost:7255/api/miias/kollaOmDetFungerar
        //så kastas undantaget och när jag sedan stegar genom koden så fångas det av mitt middleware. Jag kan se att det sker grejer i det stora svarta fönstret som poppar upp när 
        jag startar appen (kanske kallas den för debuggfönster).*/

        public Second(RequestDelegate next, ILogger<Second> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
        }
    }
}
