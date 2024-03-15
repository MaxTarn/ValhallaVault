namespace ValhallaVault.Api
{
    public class ApiCaller
    {

        private HttpClient Client { get; set; }
        public ApiCaller()
        {
            Client = new HttpClient()
            {
                BaseAddress = new Uri("https://localhost:7159")
            };

        }


        //public async Task<Root> MakeCall(string url) //kolla kommentarerna på index, onGet för att se vad allt är
        //{
        //    HttpResponseMessage response = await Client.GetAsync(url);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string json = await response.Content.ReadAsStringAsync();

        //        Root? result = JsonConvert.DeserializeObject<Root>(json);
        //        if (result != null)
        //        {
        //            return result;
        //        }

        //    }

        //    throw new HttpRequestException();
        //}
    }
}
