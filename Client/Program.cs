using System;
using RestSharp;

namespace Client
{
    class Program
    {
        private const string BaseUrl = "http://localhost:8877/";
        private const string ApiUrl = BaseUrl + "api/";

        static void Main()
        {
            Console.WriteLine("Press any key to start...");
            Console.ReadKey();
            Console.Clear();

            /*************[ 1 ]***************/
            PublicRequest();



            /*************[ 2 ]***************/
            var tokenObject1 = GetToken("limited_user", "123");



            /*************[ 3 ]***************/
            AuthorizedRequest(tokenObject1.AccessToken);



            /*************[ 4 ]***************/
            AdminRequest(tokenObject1.AccessToken);


            /*************[ 5 ]***************/
            var tokenObject2 = GetToken("admin", "123");
            AdminRequest(tokenObject2.AccessToken);


            Console.ReadKey();
        }


        private static void PublicRequest()
        {
            Console.WriteLine("[PublicRequest] -> " + ApiUrl + "home");
            var client = new RestClient(ApiUrl + "home");
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute(request);

            Console.WriteLine("Response: \n{0}\n{1}\n", response.Content, new string('_', 50));
        }


        private static TokenResult GetToken(string username, string password)
        {
            Console.ReadKey();
            Console.WriteLine("[GetToken] -> " + BaseUrl + "token");

            var client = new RestClient(BaseUrl + "token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("accept", "application/json");
            request.AddHeader("content-type", "application/x-www-form-urlencoded");

            request.AddParameter("application/x-www-form-urlencoded",
                "grant_type=password&username=" + username + "&password=" + password,
                ParameterType.RequestBody);

            var response = client.Execute<TokenResult>(request);

            Console.WriteLine("Response: \n{0}\n{1}\n", response.Content, new string('_', 50));
            return response.Data;
        }

        private static void AuthorizedRequest(string token)
        {
            Console.ReadKey();
            Console.WriteLine("[AuthorizedRequest] -> " + ApiUrl + "authorized");

            var client = new RestClient(ApiUrl + "authorized");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "bearer " + token);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute(request);

            Console.WriteLine("Response: \n{0}\n{1}\n", response.Content, new string('_', 50));

        }


        private static void AdminRequest(string token)
        {
            Console.ReadKey();
            Console.WriteLine("[AdminRequest] -> " + ApiUrl + "admin");

            var client = new RestClient(ApiUrl + "admin");
            var request = new RestRequest(Method.GET);
            request.AddHeader("authorization", "bearer " + token);
            request.AddHeader("content-type", "application/json");
            var response = client.Execute(request);
            Console.WriteLine("Response: \n{0}\n{1}\n", response.Content, new string('_', 50));

        }
    }
}
