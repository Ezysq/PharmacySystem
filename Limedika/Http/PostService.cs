using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json;
using Limedika.Data;
using Limedika.Models;
using Newtonsoft.Json.Linq;

namespace Limedika.Http
{
    public class PostService
    {
        private readonly HttpClient _httpClient;
        public PostService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async void UpdatePostalCodes(ClientsDbContext _context)
        {
            foreach (var client in _context.Clients.ToList())
            {
                var url = $"?term={client.Address}&key={_httpClient.DefaultRequestHeaders.GetValues("key").First()}";
                url = url.Replace(" ", "+");
                var response = _httpClient.GetAsync(url);
                response.Wait();
                if (response.IsCompleted)
                {
                    var data = JObject.Parse(await response.Result.Content.ReadAsStringAsync())["data"];
                    if (data.HasValues)
                    {
                        client.PostCode = "LT-" + data[0]["post_code"].ToString();
                        _context.SaveChanges();
                        _context.ClientsLogs.Add(new ClientLog(client.Name, "Client address post code was updated"));
                        _context.SaveChanges();
                    }
                }
            }

        }
    }
}
