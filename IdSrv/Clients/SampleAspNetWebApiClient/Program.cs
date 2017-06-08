using IdentityModel.Client;
using System;
using System.Net.Http;

namespace SampleAspNetWebApiClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TokenResponse response = null;

            response = GetClientToken();
            CallApi(response);

            response = GetUserToken();
            CallApi(response);

            Console.ReadLine();
        }

        static void CallApi(TokenResponse response)
        {
            var client = new HttpClient();
            client.SetBearerToken(response.AccessToken);


            //Console.WriteLine(client.GetStringAsync("https://localhost:44302/test").Result);

            Console.WriteLine(client.GetStringAsync(Tamkeen.IndividualsServices.Core.Constants.AspNetWebApiSampleApi + "identity").Result);
        }

        static TokenResponse GetClientToken()
        {
            var client = new TokenClient(
                Tamkeen.IndividualsServices.Core.Constants.TokenEndpoint,
                "silicon",
                "F621F470-9731-4A25-80EF-67A6F7C5F4B8");

            return client.RequestClientCredentialsAsync("webApi").Result;
        }

        static TokenResponse GetUserToken()
        {
            var client = new TokenClient(
                Tamkeen.IndividualsServices.Core.Constants.TokenEndpoint,
                "carbon",
                "21B5F798-BE55-42BC-8AA8-0025B903DC3B");

            return client.RequestResourceOwnerPasswordAsync("bob", "secret", "webApi").Result;
        }
    }
}
