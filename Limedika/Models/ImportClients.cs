using System.Text.Json;
using Limedika.Data;

namespace Limedika.Models
{
    public class ImportClients
    {
        public IFormFile json { get; set; }

        public ImportClients() { }
        public ImportClients(IFormFile jsonP)
        {
            json = jsonP;   
        }

        public List<Client> ParseJson()
        {
            var str = json.ContentType;
            Stream stream = json.OpenReadStream();
            List<Client> clients = new List<Client>();
            try
            {
                clients = JsonSerializer.Deserialize<List<Client>>(stream);
            }
            catch (JsonException e)
            {
                Console.WriteLine(e.Message); 
                throw (e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return clients;
        }
        
        public bool SaveJson(ClientsDbContext _context)
        {
            try
            {
                var allClients = _context.Clients.ToList();
                foreach (var client in ParseJson())
                {
                    if (allClients.Any(x => x.Name == client.Name)) continue;
                    _context.Clients.Add(client);
                    _context.SaveChanges();
                    _context.ClientsLogs.Add(new ClientLog(client.Name, "New client record created"));
                    _context.SaveChanges();
                }
                return true;
            }
            catch (JsonException e)
            {
                return false;
            }
        }

    }
}
