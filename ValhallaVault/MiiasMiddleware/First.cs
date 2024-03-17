namespace ValhallaVault.MiiasMiddleware
{
    public class First
    {
        //DETTA ÄR MIN HUVUDSAKLIGA MIDDLEWARE, DE ANDRA ÄR MEST FÖR ATT JAG SKULLE FATTA KONCEPTET
        private readonly RequestDelegate _next;
        private int _amountOfRequests;
        public First(RequestDelegate next)
        {
            _next = next;
            _amountOfRequests = 0;
        }
        /*Om jag har fattat det rätt så är detta det du beskrev som det enklaste slag av middleware.
        Tog mig hundra år att fatta vart detta skrivs ut, men hittade det i output fönstret!!!
        Och det sker exempelvis när jag skriver i url-grunkan och navigerar runt på sidan.*/

        public async Task Invoke(HttpContext context)
        {
            _amountOfRequests++;
            System.Diagnostics.Debug.WriteLine("Miia has been here, did she lyckas?");
            System.Diagnostics.Debug.WriteLine($"I think she lyckades this many times: {_amountOfRequests}");
            //nästa middleware
            await _next(context);

        }
    }
}
