namespace ValhallaVault.MiiasMiddleware
{
    public class Third //Jag tycker att denna funkar, dock förstår jag ej syfet med den. Jag ser inte något i någon av de svarta 
                       //boxarna men går jag till postman och kör en get på: https://localhost:7255/ så kan se jag att jag lagt till en Header.

    {
        private readonly RequestDelegate _next;
        public Third(RequestDelegate next)
        {

            _next = next;

        }
        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.Headers.Add("Miias-header", "Is this a middleware? Did she lyckas?");


            try
            {
                //nästa middleware
                await _next(context);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine($"This went wrong: {e.Message}");

                throw; // Att man kastar här säkerställer att andra delar av middleware arbetet fortfarande utförs?!?!?
            }
        }
    }
}
