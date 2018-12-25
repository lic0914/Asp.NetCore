using System;
using System.Net.Http;
using IdentityModel.Client;

namespace ThirdPartyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var diso = DiscoveryClient.GetAsync("http://localhost:5000").Result;
            if (diso.IsError) {
                Console.WriteLine(diso.Error);
            }
            var tokenClient = new TokenClient(diso.TokenEndpoint, "client", "secret");
            var tokenResponse = tokenClient.RequestClientCredentialsAsync("api").Result;

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
            }
            else
            {
                Console.WriteLine(tokenResponse.Json);
            }

            using(HttpClient http=new HttpClient())
            {
                http.SetBearerToken(tokenResponse.AccessToken);
                var res=http.GetAsync("http://localhost:5001/api/values").Result;

                if (res.IsSuccessStatusCode)
                {
                    Console.WriteLine(res.Content.ReadAsStringAsync().Result);
                }
                 
               
            }
            Console.ReadLine();
        }
    }
}
