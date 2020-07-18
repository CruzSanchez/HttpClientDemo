using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace HttpClientDemoConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in GetJsonData())
            {
                Console.WriteLine($"{item.Id} : {item.Title}");
            }
           
        }

        public static IEnumerable<User> GetJsonData()
        {
            List<User> users = new List<User>();
            var client = new HttpClient();
            var response = client.GetStringAsync(new Uri("https://jsonplaceholder.typicode.com/posts")).Result;

            var jArray = JArray.Parse(response);

            foreach (var token in jArray)
            {
                users.Add(JsonConvert.DeserializeObject<User>(token.ToString()));
            }

            return users;
        }
    }
}
