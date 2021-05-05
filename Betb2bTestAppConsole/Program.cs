using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Betb2bTestAppConsole.Insfrastructure;
using Betb2bTestAppModels.Models;
using Flurl;

namespace Betb2bTestAppConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateUser();
            await RemoveUser();
            await SetStatus();
            await GetUser();
        }

        private static readonly Random Rnd = new();

        private static readonly HttpClient Client = new();

        private static readonly string _baseUrl = @"http://localhost:18405/";

        public static async Task CreateUser()
        {
            Console.WriteLine("Create");
            var response = await Client.PostAsXmlAsync(Url.Combine(_baseUrl, "Auth/CreateUser"), new CreateUserRequest
            {
                User = new User
                {
                    Status = Status.Active,
                    Id = Rnd.Next(0, 10),
                    Name = "Some name " + Rnd.Next(0, 100)
                }
            });
        }

        public static async Task RemoveUser()
        {
            Console.WriteLine("Remove");
            string url = Url.Combine(_baseUrl, "Auth/RemoveUser");
            var response = await Client.PostAsJsonAsync(url,
                new RemoveUserRequest
                {
                    Id = 1
                });
        }

        public static async Task SetStatus()
        {
            Console.WriteLine("SetStatus");
            string url = Url.Combine(_baseUrl, "Auth/SetStatus");
            var args = new Dictionary<string, string>
            {
                {"Id", "1"},
                {"Status", "Active"}
            };
            var req = new HttpRequestMessage(HttpMethod.Post, url) { Content = new FormUrlEncodedContent(args) };
            var response = await Client.SendAsync(req);
        }

        public static async Task GetUser()
        {
            Console.WriteLine("Get");
            string url = Url.Combine(_baseUrl, "Public/UserInfo").SetQueryParam("id", "1");
            var response = await Client.GetAsync(url);
        }
    }
}
